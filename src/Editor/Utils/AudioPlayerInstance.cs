using Alchemy;
using ImGuiNET;
using NAudio.Wave;

namespace NST
{
    /// <summary>
    /// Static class for handling audio playback
    /// </summary>
    public static class AudioPlayerInstance
    {
        private static MemoryStream _audioStream;
        private static WaveStream _waveStream;
        private static IWavePlayer _waveOut = new WaveOutEvent();

        private static float _seekPosition = 0;
        private static float _duration;
        private static string? _name;

        private static bool _errorLoadingFile = false;

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

            audioBuffer = File.ReadAllBytes(mp3PathTmp);

            _audioStream = new MemoryStream(audioBuffer);
            _waveStream = new Mp3FileReader(_audioStream);

            _waveOut.Init(_waveStream);

            _name = name;
            _seekPosition = 0;
            _errorLoadingFile = false;

            if (autoPlay) Play();
        }

        public static void InitAudioPlayer(CSoundSample soundSample)
        {
            InitAudioPlayer(soundSample._data.ToArray(), true, soundSample.ObjectName ?? "CSoundSample");
        }

        public static void InitAudioPlayer(CSubSound subSound, bool autoPlay = false)
        {
            string? fileName = Path.GetFileNameWithoutExtension(subSound._fileName);

            _errorLoadingFile = true;

            if (fileName == null)
            {
                Console.Error.WriteLine($"Warning: Could not load audio, file name is null. ({subSound.ObjectName})");
                return;
            }

            IgArchiveFile? file = App.FindFile(fileName, FileSearchType.NameStartsWith);
            if (file == null)
            {
                Console.Error.WriteLine($"Warning: Could not load audio, file not found. ({fileName})");
                return;
            }

            if (file.GetName().EndsWith(".snd"))
            {
                InitAudioPlayer(file.Uncompress(), autoPlay, subSound._fileName);
                return;
            }

            IgzFile igz = file.ToIgzFile();

            CSoundSample? soundSample = igz.FindObject<CSoundSample>();
            if (soundSample == null)
            {
                Console.Error.WriteLine($"Warning: Could not load audio, sound sample not found. ({fileName} in {igz.GetName()})");
                return;
            }

            InitAudioPlayer(soundSample._data.ToArray(), autoPlay, subSound._fileName);
        }

        public static void Render()
        {
            ImGuiUtils.VerticalSpacing(10);
            ImGui.Separator();

            if (_errorLoadingFile)
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

            if (ImGui.Button("Extract audio"))
            {
                ExportAudio();
            }

            ImGui.Separator(); 
            ImGuiUtils.VerticalSpacing(10);
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

        public static void Dispose()
        {
            _waveOut.Dispose();
            _waveStream.Dispose();
            _audioStream.Dispose();
        }
    }
}