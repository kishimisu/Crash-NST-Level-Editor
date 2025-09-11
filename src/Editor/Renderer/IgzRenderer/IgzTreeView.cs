using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Tree of igz objects
    /// </summary>
    public class IgzTreeView : TreeView<IgzTreeNode>
    {
        public List<IgzTreeNode> ObjectNodes { get; private set; } = []; // igObject nodes

        public enum ObjectHierarchyMode { Root = 0, Named = 1, All = 2, Entities = 3 };
        private string[] _hierarchyOptions = new string[] { "Root Objects", "Named Objects", "All Objects" };
        private ObjectHierarchyMode _hierarchyMode = ObjectHierarchyMode.Root; // Tree display mode

        public IgzTreeNode? FindNode(igObject obj) => AllNodes.Values.FirstOrDefault(n => n.Object == obj);

        /// <summary>
        /// Sets the current IGZ file and rebuilds the tree
        /// </summary>
        public void SetIgz(IgzFile igz)
        {
            ObjectNodes = BuildNodes(igz);

            UpdateTypeCount(ObjectNodes);
            RebuildTree();
        }

        /// <summary>
        /// Build the tree based on the current object nodes and hierarchy mode
        /// </summary>
        protected override void RebuildTree()
        {
            _rootNodes = BuildRootNodes(ObjectNodes, _hierarchyMode);

            AllNodes = _rootNodes.Union(ObjectNodes).ToDictionary(n => n.GetDisplayName(), n => n);
        }

        /// <summary>
        /// Builds a list of igz tree nodes from an igz file
        /// </summary>
        private static List<IgzTreeNode> BuildNodes(IgzFile igz)
        {
            Dictionary<igObject, IgzTreeNode> nodeMap = [];

            Func<igObject, IgzTreeNode> AddNode = (igObject obj) =>
            {
                if (!nodeMap.TryGetValue(obj, out IgzTreeNode? node))
                {
                    node = new IgzTreeNode(obj);
                    nodeMap[obj] = node;
                }
                return node;
            };

            List<igObject> objects = igz.GetObjects();

            // Skip igObjectList & igNameList
            int start = objects.Count > 0 && objects[0] is igObjectList ? 1 : 0;
            int end = objects.Count > 0 && objects[objects.Count - 1] is igNameList ? objects.Count - 1 : objects.Count;

            for (int i = start; i < end; i++)
            {
                igObject obj = objects[i];
                IgzTreeNode node = AddNode(obj);

                foreach (igObject child in obj.GetChildren(igz, ChildrenSearchParams.IncludeHandles))
                {
                    IgzTreeNode? childNode = AddNode(child);
                    node.Children.Add(childNode);
                    childNode.Parents.Add(node);
                }
            }

            return nodeMap.Values.ToList();
        }

        /// <summary>
        /// Group objects by type and create root nodes
        /// </summary>
        private static List<IgzTreeNode> BuildRootNodes(List<IgzTreeNode> nodes, ObjectHierarchyMode hierarchyMode)
        {
            IgzTreeNode rootNode = new IgzTreeNode("Root Objects");
            IgzTreeNode unexplored = new IgzTreeNode("Unexplored Objects");
            HashSet<IgzTreeNode> exploredNodes = [];
            List<IgzTreeNode> unexploredNodes = [];

            nodes.ForEach(n => n.RootNode = false);

            // (1) Find root nodes
            unexploredNodes = AddRootNodes(rootNode, nodes, exploredNodes, n => n.IsRootNode(exploredNodes, hierarchyMode), false);
            if (unexploredNodes.Count > 0) Console.WriteLine($"(1) Unexplored nodes: {unexploredNodes.Count}");

            // (2) Fallback: find CEntities
            unexploredNodes = AddRootNodes(rootNode, unexploredNodes, exploredNodes, n => n.Object?.GetType() == typeof(CEntity) || n.Object?.GetType() == typeof(igVscIntCounterHelper));
            if (unexploredNodes.Count > 0) Console.WriteLine($"(2) Unexplored nodes: {unexploredNodes.Count}");

            // (3) Fallback: find igEntities
            unexploredNodes = AddRootNodes(rootNode, unexploredNodes, exploredNodes, n => n.Object?.GetType().IsAssignableTo(typeof(igEntity)) == true);
            if (unexploredNodes.Count > 0) Console.WriteLine($"(3) Unexplored nodes: {unexploredNodes.Count}");

            // (4) Fallback: find all nodes
            unexploredNodes = AddRootNodes(rootNode, unexploredNodes, exploredNodes, n => true);
            if (unexploredNodes.Count > 0) throw new Exception($"Unexplored nodes: {unexploredNodes.Count}");

            List<IgzTreeNode> rootNodes = GroupByType(rootNode);

            foreach (IgzTreeNode node in rootNodes)
            {
                foreach (IgzTreeNode child in node.Children)
                {
                    child.RootNode = true;
                }
                
                if (rootNodes.Count == 1 || (rootNodes.Count <= 4 && node.Children.Count < 20))
                {
                    node.NextOpen = NextOpenState.ForceOpen;
                }
            }

            return rootNodes;
        }

        private static List<IgzTreeNode> AddRootNodes(
            IgzTreeNode root, 
            List<IgzTreeNode> nodes, 
            HashSet<IgzTreeNode> exploredNodes, 
            Func<IgzTreeNode, bool> isRoot,
            bool skipExplored = true
        ) {
            foreach (IgzTreeNode node in nodes)
            {
                if (skipExplored && exploredNodes.Contains(node)) continue;
                if (isRoot(node))
                {
                    root.Children.Add(node);
                    ExploreChildren(node, exploredNodes);
                }
            }
            return nodes.Except(exploredNodes).ToList();
        }

        private static void ExploreChildren(IgzTreeNode node, HashSet<IgzTreeNode> exploredNodes)
        {
            if (exploredNodes.Contains(node)) return;

            exploredNodes.Add(node);

            foreach (IgzTreeNode child in node.Children)
            {
                ExploreChildren(child, exploredNodes);
            }
        }

        private static List<IgzTreeNode> GroupByType(IgzTreeNode node)
        {
            Dictionary<Type, List<IgzTreeNode>> typeGroups = [];

            foreach (IgzTreeNode child in node.Children)
            {
                Type? type = child.Object?.GetType();

                if (type == null) continue;

                if (!typeGroups.TryGetValue(type, out List<IgzTreeNode>? group))
                {
                    group = [];
                    typeGroups[type] = group;
                }

                group.Add(child);
            }

            var singleGroups = typeGroups.Where(e => e.Value.Count == 1).ToList();
            var sortedGroups = typeGroups.Where(e => e.Value.Count > 1).OrderBy(e => e.Key.Name).ToList();

            List<IgzTreeNode> groups = [];

            if (singleGroups.Count > 0)
            {
                IgzTreeNode singleFolder = new IgzTreeNode($"Single Objects ({singleGroups.Count})");

                foreach (var group in singleGroups)
                {
                    singleFolder.Children.Add(group.Value[0]);
                }

                groups.Add(singleFolder);
            }

            foreach (var (type, children) in sortedGroups)
            {
                IgzTreeNode typeFolder = new IgzTreeNode($"{type.Name} ({children.Count})", children);
                groups.Add(typeFolder);
            }

            return groups;
        }

        /// <summary>
        /// Assign a unique index to unnamed objects based on their type
        /// </summary>
        private static void UpdateTypeCount(List<IgzTreeNode> nodes)
        {
            var typeCount = new Dictionary<Type, int>();

            foreach (IgzTreeNode node in nodes)
            {
                if (node.Object?.GetType() is Type type)
                {
                    typeCount[type] = typeCount.GetValueOrDefault(type) + 1;
                    node.TypeCount = typeCount[type];
                }
            }
        }

        /// <summary>
        /// Select the first child node of the root folder
        /// </summary>
        public void SelectRootObject()
        {
            if (_rootNodes.Count == 1 && _rootNodes[0].Children.Count == 1)
            {
                SetSelectedNode((IgzTreeNode)_rootNodes[0].Children[0], false, false);
            }
        }

        /// <summary>
        /// Select a node corresponding to a named reference
        /// </summary>
        public void SelectNode(NamedReference reference)
        {
            IgzTreeNode? node = ObjectNodes.FirstOrDefault(n => n.Object?.GetObjectName() == reference.objectName);

            if (node != null) SetSelectedNode(node, true);
            else Console.Error.WriteLine($"Warning: No node found for {reference}");
        }

        /// <summary>
        /// Mark an object node as updated
        /// </summary>
        public void SetNodeUpdated(igObject obj)
        {
            IgzTreeNode? node = ObjectNodes.FirstOrDefault(n => n.Object == obj);

            if (node != null) node.IsUpdated = true;
            else Console.Error.WriteLine($"Warning: No node found for {obj}");
        }

        /// <summary>
        /// Render the igz tree
        /// </summary>
        public override void Render()
        {
            RenderExpandAll();
            RenderSearchBar();
            RenderDisplayModeSelector();

            UpdateSearch();

            PreviousNode = null;
            SelectNextNode = false;

            foreach (IgzTreeNode node in _rootNodes)
            {
                node.Render(this, []);
            }
        }

        /// <summary>
        /// Render a dropdown to select the display mode
        /// </summary>
        private void RenderDisplayModeSelector()
        {
            ImGui.Text("Display mode: " + _hierarchyOptions[(int)_hierarchyMode]);
            ImGui.SameLine();

            if (ImGui.BeginCombo("##DisplayMode" + GetHashCode(), _hierarchyOptions[(int)_hierarchyMode], ImGuiComboFlags.NoPreview))
            {
                OnChangeDisplayMode();
                ImGui.EndCombo();
            }
        }

        /// <summary>
        /// Callback when the display mode is changed
        /// </summary>
        private void OnChangeDisplayMode()
        {
            for (int i = 0; i < _hierarchyOptions.Length; i++)
            {
                bool isSelected = ((int)_hierarchyMode == i);

                if (ImGui.Selectable(_hierarchyOptions[i], (int)_hierarchyMode == i))
                {
                    _hierarchyMode = (ObjectHierarchyMode)i;
                    RebuildTree();
                }

                if (isSelected)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }
        }
    }
}