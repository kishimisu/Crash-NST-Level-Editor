using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// (Sound banks) Render a play/pause button for a CSubSound object
    /// </summary>
    public class CSubSoundPreview
    {
        // Current file
        private IgArchiveRenderer _archiveRenderer;
        private IgzTreeNode _subSound;
        private CSubSound _subSoundObject;

        // Target audio file
        private IgArchiveFile? _audioFile;
        private IgzFile? _audioIgz;
        private CSoundSample? _soundSample;

        private enum PlayState { Stopped, Paused, Playing };
        private PlayState _state = PlayState.Stopped;
        
        public CSubSoundPreview(IgzTreeNode subSoundNode, IgzRenderer renderer)
        {
            _subSound = subSoundNode;
            _subSoundObject = (CSubSound)subSoundNode.Object!;
            _archiveRenderer = renderer.ArchiveRenderer;

            AudioPlayerInstance.GetWaveOut().PlaybackStopped += (s, e) => _state = PlayState.Stopped;
        }        

        public void Render(IgzRenderer renderer, bool fromChildNode = false)
        {
            if (fromChildNode)
            {
                AudioPlayerInstance.Render(newAudioData =>
                {
                    if (_audioFile == null) return;

                    if (_soundSample == null) // .snd
                    {
                        _audioFile.SetData(newAudioData);
                        renderer.ArchiveRenderer.SetFileUpdated(_audioFile, false);
                        LoadAudio(true);
                    }
                    else if (_audioIgz != null) // CSoundSample
                    {
                        _soundSample._data.Set(newAudioData);
                        renderer.ArchiveRenderer.SetObjectUpdated(_audioFile, _soundSample).igz = _audioIgz;
                        LoadAudio(true);
                    }
                });
                return;
            }

            ImGui.SetNextItemAllowOverlap();
            if (ImGui.Selectable("##CSubSound" + GetHashCode()))
            {
                renderer.TreeView.SetSelectedNode(_subSound);
            }
            ImGui.SameLine();

            ImGui.Bullet();
            ImGui.SameLine();
            _subSound.RenderObjectName();

            RenderPlayButton();
        }

        public void RenderPlayButton()
        {
            ImGui.SameLine();
            if (ImGui.SmallButton((_state == PlayState.Playing ? "\uEA1D" : "\uEA1C") + "##PlaySound" + _subSound.Name))
            {
                if (_state == PlayState.Playing)
                {
                    AudioPlayerInstance.Pause();
                    _state = PlayState.Paused;
                }
                else if (_state == PlayState.Paused)
                {
                    AudioPlayerInstance.Play();
                    _state = PlayState.Playing;
                }
                else
                {
                    LoadAudio(false);
                    AudioPlayerInstance.Play();
                    _state = PlayState.Playing;
                }
            }
        }

        public void LoadAudio(bool autoPlay)
        {
            string? fileName = Path.GetFileNameWithoutExtension(_subSoundObject._fileName);

            AudioPlayerInstance.ErrorLoadingFile = true;

            if (fileName == null)
            {
                Console.Error.WriteLine($"Warning: Could not load audio, file name is null. ({_subSoundObject.ObjectName})");
                return;
            }

            // _audioFile = App.FindFile(fileName, out _, FileSearchType.NameStartsWith);
            _audioFile = _archiveRenderer.Archive.FindFile(fileName, FileSearchType.NameStartsWith);

            if (_audioFile == null)
            {
                Console.Error.WriteLine($"Warning: Could not load audio, file not found. ({fileName})");
                return;
            }

            if (_audioFile.GetName().EndsWith(".snd"))
            {
                AudioPlayerInstance.InitAudioPlayer(_audioFile.Uncompress(), autoPlay, _subSoundObject._fileName);
                return;
            }

            _audioIgz = _archiveRenderer.FileManager.GetIgz(_audioFile) ?? _audioFile.ToIgzFile();

            _soundSample = _audioIgz.FindObject<CSoundSample>();
            if (_soundSample == null)
            {
                Console.Error.WriteLine($"Warning: Could not load audio, sound sample not found. ({fileName} in {_audioIgz.GetName()})");
                return;
            }

            AudioPlayerInstance.InitAudioPlayer(_soundSample._data.ToArray(), autoPlay, _subSoundObject._fileName);
        }
    }
}