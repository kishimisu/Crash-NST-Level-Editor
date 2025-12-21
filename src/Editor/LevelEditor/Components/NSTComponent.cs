using Alchemy;
using ImGuiNET;
using System.Text.RegularExpressions;

namespace NST
{
    public class NSTComponent
    {
        public string Key { get; }
        public string DisplayName { get; }
        public bool IsUnique { get; }

        private ComponentManager _manager;
        public LevelExplorer Explorer => _manager.Explorer;
        public NSTEntity Entity => _manager.Entity;

        private readonly igComponentData _component;
        private readonly igComponentData _componentCopy;

        public igComponentData Object
        {
            get => IsUnique ? _component : _componentCopy;
        }

        public igComponentData OriginalObject => _component;

        public NSTComponent(string key, igComponentData component, ComponentManager manager, bool isUnique)
        {
            Key = key;
            IsUnique = isUnique;

            _manager = manager;
            _component = component;

            if (!isUnique)
            {
                _componentCopy = (igComponentData)component.Clone();
            }

            DisplayName = GetDisplayName();
        }

        private string GetDisplayName()
        {
            string name = _component.GetType().Name;

            if (name == "CVscComponentData")
            {
                name = Key;
                int lastDot = name.LastIndexOf('.');
                if (lastDot != -1) name = name.Substring(lastDot + 1);
                if (name.StartsWith("archetype_")) name = name.Substring(10);
            }

            if (name.StartsWith("common_")) name = name.Substring(7);
            if (name.EndsWith("Data")) name = name.Substring(0, name.Length - 4);

            var match = Regex.Match(Key, @"(\d+)$");
            if (match.Success) name += " " + match.Value;

            return name;
        }

        public string GetBaseKeyName()
        {
            var match = Regex.Match(Key, @"(\d+)$");
            return match.Success ? Key.Substring(0, Key.Length - match.Value.Length) : Key;
        }

        public void Render()
        {
            RenderName();

            if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenBlockedByActiveItem | ImGuiHoveredFlags.AllowWhenBlockedByPopup))
            {
                if (ImGuiUtils.SmallButtonAlignRight("\uE994", "##componentActions" + DisplayName))
                {
                    ImGui.OpenPopup("ComponentActionsPopup");
                    _manager.PopupComponent = this;
                }
            }

            ImGui.Indent();
            ComponentRenderer.RenderComponent(this);
            ImGui.Unindent();

            ImGui.Spacing();
        }

        public void RenderName()
        {
            ImGui.PushStyleColor(ImGuiCol.Text, _component.GetType().GetUniqueColor());
            ImGui.SeparatorText(DisplayName);
            ImGui.PopStyleColor();
        }

        public void RenderAdvancedProperties(igObject obj, IReadOnlyList<CachedFieldAttr> fields, string name = "Advanced Properties...")
        {
            if (ImGui.TreeNodeEx($"{name}##{obj.GetType()}", ImGuiTreeNodeFlags.NoTreePushOnOpen))
            {
                IgzRenderer renderer = Explorer.FileManager.GetOrCreateRenderer(Entity.ArchiveFile, Explorer.ArchiveRenderer);

                Action? onUpdate = null;

                onUpdate = () =>
                {
                    renderer.OnUpdate -= onUpdate;
                    SetUpdated(true);
                };

                renderer.OnUpdate += onUpdate;

                renderer.RenderObject(obj, fields);

                renderer.OnUpdate -= onUpdate;
            }
        }

        public void SetUpdated(bool makeTreeDirty) => SetUpdated(null, makeTreeDirty);

        public void SetUpdated(igObject? obj = null, bool makeTreeDirty = false, IgArchiveFile? file = null)
        {
            if (!IsUnique)
            {
                NSTComponent newComponent = _manager.MakeUnique(this);
                obj = newComponent.Object;
            }

            Explorer.ArchiveRenderer.SetObjectUpdated(file ?? Entity.ArchiveFile, obj ?? _component, makeTreeDirty || !IsUnique);
        }
    }
}