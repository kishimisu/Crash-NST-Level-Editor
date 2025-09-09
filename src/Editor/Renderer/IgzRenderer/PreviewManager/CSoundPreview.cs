using Alchemy;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// (Sound banks) Render a CSound object and all of its CSubSound objects
    /// </summary>
    public class CSoundPreview
    {
        private IgzTreeNode _sound;
        private List<CSubSoundPreview> _subSounds = [];

        public CSoundPreview(IgzRenderer renderer, CSound sound)
        {
            List<CSubSoundPreview>? subSounds = sound._subSoundList?._data.Select(e => new CSubSoundPreview(renderer.FindNode(e))).ToList();

            if (subSounds != null)
            {
                _subSounds = subSounds;
            }
            else
            {
                Console.Error.WriteLine($"Warning: subsound list not found for {sound._name}.");
            }

            _sound = renderer.FindNode(sound);
            _sound.SoundPreview = this;
        }

        public void Render(IgzRenderer renderer, bool fromChildNode = false)
        {
            if (fromChildNode)
            {
                foreach (CSubSoundPreview subSound in _subSounds)
                {
                    subSound.Render(renderer);
                }
                return;
            }

            ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanAvailWidth | ImGuiTreeNodeFlags.OpenOnArrow;

            if (_subSounds.Count == 0)
            {
                flags |= ImGuiTreeNodeFlags.Leaf;
            }
            if (_subSounds.Count > 1)
            {
                flags |= ImGuiTreeNodeFlags.DefaultOpen;
            }

            Vector2 min = ImGui.GetItemRectMin();
            float arrowStart = ImGui.GetCursorPosX();

            ImGui.SetNextItemAllowOverlap();

            bool isOpen = ImGui.TreeNodeEx("##CSound" + GetHashCode(), flags);
            ImGui.SameLine(0, 0);

            if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
            {
                float arrowWidth = ImGui.GetCursorPosX() - arrowStart;
                Vector2 max = min + new Vector2(arrowWidth, ImGui.GetFrameHeight());

                if (!ImGui.IsMouseHoveringRect(min, max))
                {
                    renderer.TreeView.SetSelectedNode(_sound, true);
                }
            }

            _sound.RenderObjectName();

            ImGui.SameLine();
            ImGui.Text($"({_subSounds.Count})");

            if (isOpen)
            {
                foreach (CSubSoundPreview subSound in _subSounds)
                {
                    subSound.Render(renderer);
                }

                ImGui.TreePop();
            }
            else if (_subSounds.Count == 1)
            {
                _subSounds[0].RenderPlayButton(renderer);
            }

            ImGui.Separator();
        }
    }
}