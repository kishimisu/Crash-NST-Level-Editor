using Alchemy;
using ImGuiNET;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NST
{
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

            if (obj.Children.Count == 1 && obj.Children.First() is NSTSpline spline)
            {
                children = spline.Children;
                sortChildren = false;
            }

            foreach (NSTObject child in children)
            {
                if (added.Contains(child)) continue;
                if (child is NSTEntity entity && !entity.IsSpawned) continue;

                Children.Add(new EntityTreeNode(child.GetObject().ObjectName ?? "<No name>", child, added));
            }

            if (sortChildren)
            {
                Children.Sort((a, b) => a.Name.CompareTo(b.Name));
            }
        }

        public void Render(EntityTreeView tree)
        {
            ImGuiTreeNodeFlags? flags = SetupNode(tree) | ImGuiTreeNodeFlags.AllowOverlap;

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

        public void RenderName(string displayName)
        {
            ImGui.SameLine();

            if (Object is NSTEntity)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Object.GetObject().GetType().GetUniqueColor());
                ImGui.Text("\uEA1E");
                ImGui.PopStyleColor();
                ImGui.SameLine();
            }

            if (Color != null) ImGui.PushStyleColor(ImGuiCol.Text, Color.Value);

            ImGui.Text(displayName);

            if (Color != null) ImGui.PopStyleColor();
        }

        public void RenderNode(EntityTreeView tree, ImGuiTreeNodeFlags flags)
        {
            NSTEntity? entity = Object as NSTEntity;

            string displayName = Name;

            if (entity?.IsPrefabInstance == true) displayName = $"[Prefab] {displayName}";
            else if (Object is NSTSpline) displayName = "Spline: " + displayName;
            else if (Object is NSTSplineControlPoint cp) displayName = "Control point #" + cp._parent.Object._data?._data.IndexOf(cp.Object);

            if (Object == null || tree.SelectedNode != this)
            {
                IsOpen = ImGui.TreeNodeEx("###" + Name, flags);

                if (Object != null && ImGui.IsItemClicked()) 
                {
                    tree.SetSelectedNode(this);
                    tree.Explorer.SelectObject(Object);
                }

                HandleNavigation(tree);
                RenderName(displayName);
                
                return;
            }

            float buttonsWidth = ImGui.CalcTextSize("Focus").X + ImGui.CalcTextSize("Open").X + ImGui.GetStyle().FramePadding.X * 6;
            displayName = ImGuiUtils.TruncateTextToFit(displayName, ImGui.GetContentRegionAvail().X - buttonsWidth - ImGui.GetStyle().FramePadding.X * 4);

            IsOpen = ImGui.TreeNodeEx("###" + Name, flags);

            HandleNavigation(tree);
            ImGui.SameLine();
            RenderName(displayName);

            bool clickedNode = ImGui.IsItemClicked();
            bool clickedFocus = false;
            bool clickedOpen = false;

            if (tree.SelectedNode == this)
            {
                ImGui.SameLine();
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonsWidth);
                ImGui.SmallButton("Focus");
                clickedFocus = ImGui.IsItemClicked();

                ImGui.SameLine();
                ImGui.SmallButton("Open");
                clickedOpen = ImGui.IsItemClicked();
            }

            if (clickedFocus)
            {
                tree.Explorer.FocusObject(Object.GetObject());
            }
            else if (clickedOpen)
            {
                IgzRenderer? igzRenderer = tree.Explorer._fileManager.GetOrCreateRenderer(Object.ToReference(), tree.Explorer._archiveRenderer);

                if (igzRenderer != null)
                {
                    if (igzRenderer.IsOpenAsWindow)
                    {
                        ImGui.SetWindowFocus(igzRenderer.GetWindowName());
                    }
                    else
                    {
                        App.FocusRenderer(igzRenderer);
                    }
                }
            }
            else if (clickedNode) 
            {
                tree.SetSelectedNode(this);
                tree.Explorer.SelectObject(Object);
            }
        }
    }

    public class EntityTreeView : TreeView<EntityTreeNode>
    {
        public LevelExplorer Explorer { get; }

        public EntityTreeView(LevelExplorer explorer, List<NSTObject> entities)
        {

            Explorer = explorer;
            RebuildTree(entities);
        }

        public void RebuildTree(List<NSTObject> objects)
        {
            Dictionary<string, List<NSTObject>> types = new Dictionary<string, List<NSTObject>>() { { "Crates", [] }, { "Prefabs", [] } };
            Dictionary<string, uint> colors = [];

            List<NSTObject> entities = [];
            List<NSTObject> crates = [];
            List<NSTObject> prefabs = [];
            List<NSTObject> templates = [];
            List<NSTObject> hidden = [];

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
                    else if (entity.GetObject().GetType() == typeof(CEntity) && entity.GetObject().ObjectName!.StartsWith("Crate_")) crates.Add(obj);
                    else if (objects.Any(e => e.Children.Contains(obj))) continue;
                    else if (entity.IsPrefabChild) continue;
                    else added = false;
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

            if (crates.Count > 0) types["Crates"] = crates;
            if (prefabs.Count > 0) types["Prefabs"] = prefabs;
            if (templates.Count > 0) types["Templates"] = templates;
            if (hidden.Count > 0) types["Hidden"] = hidden;

            colors["Crates"] = 0xFF00A7FF;
            colors["Prefabs"] = 0xFF00C7FF;
            colors["Templates"] = 0xFF999980;
            colors["Hidden"] = 0xFF808080;

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
                    // string? number = match.Groups[2].Success ? match.Groups[2].Value : null;

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
                string rootName = $"{t.Key} ({totalCount})";

                if (subFolders.Count == 1 && subFolders.First().IsFolder)
                {
                    subFolders = subFolders.First().Children.Cast<EntityTreeNode>().ToList();
                }

                EntityTreeNode rootNode = new EntityTreeNode(rootName, subFolders, colors[t.Key]);
                AllNodes.Add(rootNode);
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
                    SetSelectedNode(node, expandNode: true);
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

        public override void Render()
        {
            PreviousNode = null;
            SelectNextNode = false;

            foreach (EntityTreeNode node in _rootNodes)
            {
                node.Render(this);
            }
        }
    }
}