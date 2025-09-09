using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// (Sound banks) Render a play/pause button for a CSubSound object
    /// </summary>
    public class CSubSoundPreview
    {
        private IgzTreeNode _subSound;

        private enum PlayState { Stopped, Paused, Playing };
        private PlayState _state = PlayState.Stopped;
        
        public CSubSoundPreview(IgzTreeNode subSoundNode)
        {
            _subSound = subSoundNode;

            AudioPlayerInstance.GetWaveOut().PlaybackStopped += (s, e) => _state = PlayState.Stopped;
        }        

        public void Render(IgzRenderer renderer, bool fromChildNode = false)
        {
            if (fromChildNode)
            {
                AudioPlayerInstance.Render();
                return;
            }

            ImGui.SetNextItemAllowOverlap();
            if (ImGui.Selectable("##CSubSound" + GetHashCode()))
            {
                renderer.TreeView.SetSelectedNode(_subSound, true);
            }
            ImGui.SameLine();

            ImGui.Bullet();
            ImGui.SameLine();
            _subSound.RenderObjectName();

            RenderPlayButton(renderer);
        }

        public void RenderPlayButton(IgzRenderer renderer)
        {
            ImGui.SameLine();
            if (ImGui.SmallButton((_state == PlayState.Playing ? "\uEA1D" : "\uEA1C") + "##PlaySound" + GetHashCode()))
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
                    LoadAudio(true);
                    _state = PlayState.Playing;
                }
            }
        }

        public void LoadAudio(bool autoPlay)
        {
            AudioPlayerInstance.InitAudioPlayer((CSubSound)_subSound.Object!, autoPlay);
        }
    }
}