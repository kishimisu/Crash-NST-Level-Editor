using Alchemy;
using ImGuiNET;
using NAudio.Lame;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace NST
{
    /// <summary>
    /// Static class for handling audio playback
    /// </summary>
    public static class AudioPlayerInstance
    {
        private struct FSB5Header
        {
            public u32 id = 0x35425346; // FSB5
            public u32 version = 1;
            public u32 numSamples = 1;
            public u32 sampleHeadersSize = 8;
            public u32 nameTableSize = 0;
            public u32 dataSize = 0;
            public u32 mode = 11; // MPEG
            public FSB5Header() {}
        }
        
        private static MemoryStream _audioStream;
        private static WaveStream _waveStream;
        private static IWavePlayer _waveOut = new WaveOutEvent();
        private static byte[] _rawData;

        private static float _seekPosition = 0;
        private static float _duration;
        private static string? _name;

        public static bool ErrorLoadingFile { get; set; } = false;
        public static bool AutoPlayAudio { get; set; } = false;

        public static void Play() => _waveOut.Play();
        public static void Pause() => _waveOut.Pause();
        public static void Stop() => _waveOut.Stop();

        public static IWavePlayer GetWaveOut() => _waveOut;

        public static void InitAudioPlayer(byte[] audioBuffer, bool autoPlay = false, string? name = null)
        {
            if (_waveOut.PlaybackState != PlaybackState.Stopped)
            {
                _waveOut.Stop();
            }

            string rawPathTmp = LocalStorage.GetStoragePath("audio.tmp");
            string mp3PathTmp = LocalStorage.GetStoragePath("audio.mp3");
            File.WriteAllBytes(rawPathTmp, audioBuffer);

            using (MediaFoundationReader mediaFoundationReader = new MediaFoundationReader(rawPathTmp))
            {
                _duration = (float)mediaFoundationReader.TotalTime.TotalSeconds;
                MediaFoundationEncoder.EncodeToMp3(mediaFoundationReader, mp3PathTmp, 192000);
            }

            _rawData = audioBuffer;

            audioBuffer = File.ReadAllBytes(mp3PathTmp);

            _audioStream = new MemoryStream(audioBuffer);
            _waveStream = new Mp3FileReader(_audioStream);

            _waveOut.Init(_waveStream);

            _name = name;
            _seekPosition = 0;
            ErrorLoadingFile = false;

            _waveOut.Volume = 0.25f;

            if (AutoPlayAudio && autoPlay) Play();
        }

        public static void InitAudioPlayer(CSoundSample soundSample)
        {
            InitAudioPlayer(soundSample._data.ToArray(), true, soundSample.ObjectName ?? "CSoundSample");
        }

        public static void Render(Action<byte[]>? onReplace = null)
        {
            ImGuiUtils.VerticalSpacing(10);
            ImGui.Separator();

            if (ErrorLoadingFile)
            {
                ImGui.Text("Audio file not found: " + _name);
                return;
            }
            
            if (ImGui.Button(_waveOut.PlaybackState == PlaybackState.Playing ? "Pause" : "Play"))
            {
                TogglePlayPause();
            }
            ImGui.SameLine();
            ImGui.Text("Audio duration: " + _duration + "s");

            _seekPosition = (float)_waveStream.Position / _waveStream.Length * _duration;
            if (_waveOut.PlaybackState == PlaybackState.Stopped && _seekPosition > 0)
            {
                Seek(0);
            }

            ImGui.SetNextItemWidth(-1);
            if (ImGui.SliderFloat("##Progress", ref _seekPosition, 0.0f, _duration, $"%.2fs/{_duration:F2}s"))
            {
                Seek(_seekPosition);
            }

            if(ImGui.Button("Extract audio"))
            {
                ExportAudio();
            }
            
            ImGui.SameLine();

            if (ImGui.Button("Import audio"))
            {
                List<string> paths = FileExplorer.OpenFiles("", FileExplorer.EXT_AUDIO, false);
                if (paths.Count == 1)
                {
                    ModalRenderer.ShowLoadingModal("Importing audio...");
                    Task.Run(() =>
                    {
                        _rawData = ReplaceAudio(_rawData, paths[0]);
                        onReplace?.Invoke(_rawData);
                        ModalRenderer.CloseLoadingModal();
                    })
                    .ContinueWith(t => 
                    {
                        if (t.IsFaulted && t.Exception != null)
                        {
                            foreach (var ex in t.Exception.InnerExceptions)
                            {
                                CrashHandler.Log($"Error importing audio: {ex.Message}\n{ex.StackTrace}");
                            }
                            string logPath = CrashHandler.WriteLogsToFile();
                            ModalRenderer.ShowMessageModal("Error", $"An error occured while importing the audio\n\nLog file: {logPath}");
                        }
                    }, 
                    TaskContinuationOptions.OnlyOnFaulted);
                }
            }

            ImGui.Separator(); 
            ImGuiUtils.VerticalSpacing(10);
        }

        public static void RenderAudioMenu()
        {
            if (ImGui.MenuItem("Auto-play audio", null, AutoPlayAudio))
            { 
                AutoPlayAudio = !AutoPlayAudio;
                LocalStorage.Set("auto_play_audio", AutoPlayAudio);
            }
        }

        private static void TogglePlayPause()
        {
            if (_waveOut.PlaybackState == PlaybackState.Playing)
            {
                _waveOut.Pause();
            }
            else
            {
                _waveOut.Play();
            }
        }

        private static void Seek(float progress)
        {
            long newPosition = (long)(_waveStream.Length * progress / _duration);
            _waveStream.Position = newPosition;
        }

        private static void ExportAudio()
        {
            string? path = FileExplorer.SaveFile("", FileExplorer.EXT_AUDIO, _name + ".mp3");
            if (path == null) return;

            File.WriteAllBytes(path, _audioStream.ToArray());
        }

        private static byte[] ReplaceAudio(byte[] data, string inputPath)
        {
            using var readStream = new MemoryStream(data);
            using var reader = new BinaryReader(readStream);

            var header = reader.ReadStruct<FSB5Header>();

            if (header.id != 0x35425346) throw new Exception("Unsupported file format: " + header.id);
            if (header.version != 1) throw new Exception("Unsupported version: " + header.version);
            if (header.mode != 11) throw new Exception("Unsupported mode: " + header.mode);
            if (header.numSamples != 1) throw new Exception("Unsupported sample count: " + header.numSamples);

            int mpegFrameStart = 16;
            do 
            {
                mpegFrameStart += 16;
                if (mpegFrameStart >= reader.BaseStream.Length) throw new Exception("Reached end of stream");
                reader.Seek(mpegFrameStart);
            }
            while (reader.ReadByte() != 0xFF || reader.ReadByte() < 0xFA);

            byte[] mpegStream = ExtractMPEGFrames(inputPath);

            using var writeStream = new MemoryStream();
            using var writer = new BinaryWriter(writeStream);

            writer.Write(data, 0, mpegFrameStart);

            writer.Seek(20, SeekOrigin.Begin);
            writer.Write(mpegStream.Length);

            writer.Seek(mpegFrameStart, SeekOrigin.Begin);
            writer.Write(mpegStream);

            return writeStream.ToArray();
        }

        private static byte[] ExtractMPEGFrames(string inputPath)
        {
            using var reader = new AudioFileReader(inputPath);
            
            var sampleProvider = new WdlResamplingSampleProvider(reader, 48000);

            int channels = reader.WaveFormat.Channels;
            var pcmFormat = new WaveFormat(48000, 16, channels);
            var pcmStream = new SampleToWaveProvider16(sampleProvider);

            var mp3Config = new LameConfig
            {
                BitRate = 128,
                OutputSampleRate = 48000,
                Mode = channels == 1 ? MPEGMode.Mono : MPEGMode.Stereo,
                VBR = VBRMode.ABR,
                WriteVBRTag = false
            };

            using var output = new MemoryStream();
            using var mp3Writer = new LameMP3FileWriter(output, pcmStream.WaveFormat, mp3Config);

            byte[] buffer = new byte[pcmStream.WaveFormat.AverageBytesPerSecond];
            int bytesRead;

            while ((bytesRead = pcmStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                mp3Writer.Write(buffer, 0, bytesRead);
            }

            mp3Writer.Flush();

            return output.ToArray();
        }

        public static void Dispose()
        {
            _waveOut.Dispose();
            _waveStream.Dispose();
            _audioStream.Dispose();
        }
    }
}