using Alchemy;
using ImGuiNET;
using System.Text.RegularExpressions;

namespace NST
{
    public class EntityTreeView : TreeView<EntityTreeNode>
    {
        public LevelExplorer Explorer { get; }

        private static readonly Dictionary<string, List<string>> _objectGroupNames = new Dictionary<string, List<string>>()
        {
            { "Object groups", new List<string>() { "igEntity", "Prefabs", "Crates", "Splines", "CPlayerStartEntity" } },
            { "Entities", new List<string>() { "CEntity", "CGameEntity", "CPhysicalEntity", "CActor", "Other" } },
            { "Triggers / colliders", new List<string>() { "CScriptTriggerEntity", "CDynamicClipEntity" } },
            { "Cameras", new List<string>() { "Cameras", "CCameraBox" } },
            { "Hidden", new List<string>() { "Templates", "Hidden" } }
        };

        private Dictionary<string, List<EntityTreeNode>> _objectGroups = [];

        public EntityTreeView(LevelExplorer explorer, List<NSTObject> entities)
        {
            Explorer = explorer;
            RebuildTree(entities);
        }

        public override void Render()
        {
            PreviousNode = null;
            SelectNextNode = false;

            foreach ((string group, List<EntityTreeNode> nodes) in _objectGroups)
            {
                if (nodes.Count == 0) continue;
                
                ImGui.SeparatorText(group);

                foreach (EntityTreeNode node in nodes.ToList())
                {
                    node.Render(this);
                }
                
                ImGui.Spacing();
            }
        }

        public void RebuildTree(List<NSTObject> objects)
        {
            Dictionary<string, List<NSTObject>> types = new Dictionary<string, List<NSTObject>>() { { "Crates", [] }, { "Prefabs", [] } };
            Dictionary<string, uint> colors = [];

            List<NSTObject> entities = [];
            List<NSTObject> crates = [];
            List<NSTObject> prefabs = [];
            List<NSTObject> cameras = [];
            List<NSTObject> splines = [];
            List<NSTObject> templates = [];
            List<NSTObject> other = [];
            List<NSTObject> hidden = [];

            _objectGroups = new Dictionary<string, List<EntityTreeNode>>()
            {
                { "Object groups", new List<EntityTreeNode>() },
                { "Entities", new List<EntityTreeNode>() },
                { "Triggers / colliders", new List<EntityTreeNode>() },
                { "Cameras", new List<EntityTreeNode>() },
                { "Hidden", new List<EntityTreeNode>() }
            };

            foreach (NSTObject obj in objects)
            {
                bool added = false;

                if (obj is NSTEntity entity)
                {
                    added = true;

                    if (entity.IsPrefabTemplate) continue;
                    else if (entity.IsPrefabInstance) prefabs.Add(obj);
                    else if (entity.IsTemplate) templates.Add(obj);
                    else if (entity.IsHidden) hidden.Add(obj);
                    else if (entity.IsPrefabChild) continue;
                    else if (!entity.IsSpawned && entity.Parents.Count > 0) continue;
                    // else if (!entity.IsSpawned && objects.Any(e => e.Children.Contains(obj))) continue;
                    else if (entity.GetObject().GetType() == typeof(CEntity) && entity.GetObject().ObjectName!.StartsWith("Crate_")) crates.Add(obj);
                    else if (entity.Spline != null && entity.Children.Count == 1) splines.Add(obj);
                    else if (entity.Object is CScriptTriggerEntity && (entity.Parents.Count > 0 || entity.Children.Any(e => e.Children.Contains(entity)))) continue;
                    else if (entity.Model == null && entity.Object is not CScriptTriggerEntity && entity.Object is not CDynamicClipEntity && entity.Object is not CPlayerStartEntity) other.Add(obj);
                    else added = false;
                }
                else if (obj.GetObject() is CCamera)
                {
                    cameras.Add(obj);
                    added = true;
                }
                
                if (!added)
                {
                    Type type = obj.GetObject().GetType();

                    if (!types.ContainsKey(type.Name))
                    {
                        types.Add(type.Name, []);
                        colors.Add(type.Name, type.GetUniqueColor());
                    }
                    types[type.Name].Add(obj);
                }
            }

            types["Crates"] = crates;
            types["Prefabs"] = prefabs;
            types["Cameras"] = cameras;
            types["Splines"] = splines;
            types["Other"] = other;
            types["Templates"] = templates;
            types["Hidden"] = hidden;

            types = types.Where(kvp => kvp.Value.Count > 0).ToDictionary();

            var start = new List<string>() { "igEntity", "Prefabs", "Crates", "Splines", "CPlayerStartEntity", "CEntity", "CGameEntity", "CPhysicalEntity" };
            var end = new List<string>() { "Other", "CScriptTriggerEntity", "CDynamicClipEntity", "Cameras", "CCameraBox", "Templates", "Hidden" };
            var middle = types.Keys.Where(k => !start.Contains(k) && !end.Contains(k)).ToList();
            var order = start.Concat(middle).Concat(end).ToList();

            types = order.Where(o => types.ContainsKey(o)).ToDictionary(o => o, o => types[o]);

            AllNodes.Clear();

            _rootNodes = types.Select(t => 
            {
                Dictionary<string, List<EntityTreeNode>> names = [];

                foreach (NSTObject entity in t.Value)
                {
                    string name = entity.GetObject().ObjectName ?? "<No name>";
                    Match match = Regex.Match(name, @"^(.*?)(?:_)?(\d+)?$");

                    if (!match.Success) {
                        Console.WriteLine($"Warning: Could not parse {name} into name and number");
                        continue;
                    }

                    string prefix = match.Groups[1].Value;

                    if (!names.ContainsKey(prefix)) names.Add(prefix, []);
                    EntityTreeNode entityNode = new EntityTreeNode(name, entity);
                    names[prefix].Add(entityNode);
                    AllNodes.Add(entityNode);
                }

                List<EntityTreeNode> subFolders = names.Select(n => {
                    if (n.Value.Count == 1) {
                        AllNodes.Add(n.Value[0]);
                        return n.Value[0];
                    }
                    string name = $"{n.Key} ({n.Value.Count})";
                    EntityTreeNode folderNode = new EntityTreeNode(name, n.Value);
                    AllNodes.Add(folderNode);
                    return folderNode;
                })
                .OrderBy(n => n.Children.Count == 0)
                .ThenBy(n => n.Object != null)
                .ThenBy(n => n.Object != null ? n.Object.GetObject().GetType().Name : "")
                .ThenBy(n => n.Name)
                .ToList();

                int totalCount = subFolders.Sum(n => n.IsFolder ? Math.Max(1, n.Children.Count) : 1);
                string rootName = $"{(t.Key == "igEntity" ? "Static objects" : t.Key == "CPlayerStartEntity" ? "Player Start" : t.Key)} ({totalCount})";

                if (subFolders.Count == 1 && subFolders.First().IsFolder)
                {
                    subFolders = subFolders.First().Children.Cast<EntityTreeNode>().ToList();
                }

                EntityTreeNode rootNode = new EntityTreeNode(rootName, subFolders, GetUniqueColor(t.Key));
                AllNodes.Add(rootNode);

                string? groupName = _objectGroupNames.FirstOrDefault(e => e.Value.Contains(t.Key)).Key ?? "Entities";
                _objectGroups[groupName].Add(rootNode);

                return rootNode;
            })
            .ToList();
        }

        public void SelectObject(NSTObject obj) => SelectObjectRecursive(obj, AllNodes.Cast<TreeNode>().ToList());
        private bool SelectObjectRecursive(NSTObject obj, List<TreeNode> nodes)
        {
            foreach (EntityTreeNode node in nodes)
            {
                if (node.Object == obj)
                {
                    SetSelectedNode(node, keyboardFocus: false, expandNode: true);
                    return true;
                }

                foreach (EntityTreeNode child in node.Children)
                {
                    if (SelectObjectRecursive(obj, child.Children))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static uint GetUniqueColor(string name)
        {
            Random rng = new Random((int)NamespaceUtils.ComputeHash(name)+1);
            int r = rng.Next(130, 255);
            int g = rng.Next(130, 255);
            int b = rng.Next(130, 255);
            return 0xff000000 | (uint)((b << 16) | (g << 8) | r);
        }
    }

    public class EntityTreeNode : TreeNode
    {
        public NSTObject Object { get; }
        public uint? Color { get; set; }

        public EntityTreeNode(string name, List<EntityTreeNode> childNodes, uint? color = null)
        {
            Name = name;
            IsFolder = true;
            Color = color;
            
            foreach (EntityTreeNode child in childNodes)
            {
                Children.Add(child);
            }
        }

        public EntityTreeNode(string name, NSTObject obj, HashSet<NSTObject>? added = null)
        {
            Name = name;
            Object = obj;

            added ??= new HashSet<NSTObject>();
            added.Add(obj);

            HashSet<NSTObject> children = obj.Children;
            bool sortChildren = (obj is NSTEntity);
            bool isSpawned = (obj is NSTEntity entity && (entity.IsSpawned && entity.Model != null));

            HashSet<NSTObject> prev = added.ToHashSet();

            foreach (NSTObject child in children)
            {
                if (child is NSTSpline) continue;
                // if (isSpawned && (child is NSTEntity childEntity && !childEntity.IsSpawned)) continue;
                if (isSpawned && child.GetObject() is not CScriptTriggerEntity) continue;
                if (added.Contains(child)) continue;
                Children.Add(new EntityTreeNode(child.GetObject().ObjectName ?? "<No name>", child, added));
            }

            added = prev;

            if (sortChildren)
            {
                Children.Sort((a, b) => a.Name.CompareTo(b.Name));
            }
        }

        public void Render(EntityTreeView tree)
        {
            ImGuiTreeNodeFlags? flags = SetupNode(tree, onFocus: () => 
            { 
                if (Object != null && NextFocus == NextFocusState.FocusAndKeyboard)
                {
                    tree.Explorer.SelectObject(Object, fromTree: true);
                }
            });

            if (flags == null) return;

            RenderNode(tree, flags.Value);

            tree.PreviousNode = this;

            if (IsOpen)
            {
                foreach (EntityTreeNode child in Children)
                {
                    child.Render(tree);
                }
                ImGui.TreePop();
            }
        }

        private void RenderName(string displayName)
        {
            ImGui.SameLine(0, 0);

            if (Object != null)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Object.GetObject().GetType().GetUniqueColor());
                ImGui.Text("\uEA1E");
                ImGui.PopStyleColor();
                ImGui.SameLine(0, 5);
            }

            if (Color != null) ImGui.PushStyleColor(ImGuiCol.Text, Color.Value);

            ImGui.Text(displayName);

            if (Color != null) ImGui.PopStyleColor();
        }

        private void RenderNode(EntityTreeView tree, ImGuiTreeNodeFlags flags)
        {
            if (Object == null)
            {
                RenderFolderNode(tree, flags);
                return;
            }

            if (Object.IsSelected && (Object is NSTEntity e && e.IsPrefabChild || Object.Parents.Count == 0)) flags |= ImGuiTreeNodeFlags.Selected;

            string displayName = Object is NSTEntity entity && entity.IsPrefabInstance ? $"[Prefab] {Name}" : Name;

            IsOpen = ImGui.TreeNodeEx("###" + Name, flags);

            if (ImGui.IsItemClicked())
            {
                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    tree.Explorer.LookAtObject(Object);
                }
            }

            HandleNavigation(tree);
            RenderName(displayName);
        }

        private void RenderFolderNode(EntityTreeView tree, ImGuiTreeNodeFlags flags)
        {
            IsOpen = ImGui.TreeNodeEx("###" + Name, flags);

            HandleNavigation(tree);
            RenderName(Name);
        }
    }
}