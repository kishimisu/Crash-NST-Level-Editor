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
        public IgzRenderer Renderer { get; } // Parent renderer

        public enum ObjectHierarchyMode { Root = 0, Named = 1, Updated = 2, All = 3 };
        private string[] _hierarchyOptions = new string[] { "Root Objects", "Named Objects", "Updated Objects", "All Objects" };
        private ObjectHierarchyMode _hierarchyMode = ObjectHierarchyMode.Root; // Tree display mode

        public IgzTreeNode? FindNode(igObject obj) => AllNodes.FirstOrDefault(n => n.Object == obj);

        public IgzTreeView(IgzRenderer renderer) => Renderer = renderer;

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

            AllNodes = _rootNodes.Union(ObjectNodes).ToList();
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

            List<igObject> objects = igz.Objects;

            // Skip igObjectList & igNameList
            bool excludeObjectAndNameList = true;
            int start = excludeObjectAndNameList && objects.Count > 0 && objects[0].GetType() == typeof(igObjectList) ? 1 : 0;

            for (int i = start; i < objects.Count; i++)
            {
                igObject obj = objects[i];

                if (excludeObjectAndNameList && obj.GetType() == typeof(igNameList))
                {
                    excludeObjectAndNameList = false;
                    continue;
                }

                IgzTreeNode node = AddNode(obj);

                foreach (igObject child in obj.GetChildren(igz, ChildrenSearchParams.IncludeHandles))
                {
                    IgzTreeNode? childNode = AddNode(child);
                    node.Children.Add(childNode);
                    childNode.Parents.Add(node);
                    childNode.InitialParentCount++;
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

            if (hierarchyMode != ObjectHierarchyMode.Updated) 
            {
                // (2) Fallback: find CEntities
                unexploredNodes = AddRootNodes(rootNode, unexploredNodes, exploredNodes, n => n.Object?.GetType() == typeof(CEntity) || n.Object?.GetType() == typeof(igVscIntCounterHelper));
                if (unexploredNodes.Count > 0) Console.WriteLine($"(2) Unexplored nodes: {unexploredNodes.Count}");

                // (3) Fallback: find igEntities
                unexploredNodes = AddRootNodes(rootNode, unexploredNodes, exploredNodes, n => n.Object?.GetType().IsAssignableTo(typeof(igEntity)) == true);
                if (unexploredNodes.Count > 0) Console.WriteLine($"(3) Unexplored nodes: {unexploredNodes.Count}");

                // (4) Fallback: find all nodes
                unexploredNodes = AddRootNodes(rootNode, unexploredNodes, exploredNodes, n => true);
                if (unexploredNodes.Count > 0) throw new Exception($"Unexplored nodes: {unexploredNodes.Count}");
            }

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
        /// Rebuild the children of a node and update 
        /// the parents of the previous children.
        /// </summary>
        public void RebuildNode(IgzTreeNode? node)
        {
            if (node?.Object == null) return;

            List<TreeNode> prevChildren = node.Children.ToList();

            // Clear previous children
            node.Children.Clear();

            // Add new children
            foreach (igObject child in node.Object.GetChildren(Renderer.Igz, ChildrenSearchParams.IncludeHandles))
            {
                IgzTreeNode? childNode = ObjectNodes.Find(e => e.Object == child);

                if (childNode == null)
                {
                    Console.WriteLine($"Warning: No node found for {child} while rebuilding {node.Object}");
                    continue;
                }

                node.Children.Add(childNode);
            }

            // Unparent previous children
            foreach (IgzTreeNode prevChild in prevChildren)
            {
                if (!node.Children.Contains(prevChild))
                {
                    prevChild.Parents.Remove(node);
                }
            }

            // Parent new children
            foreach (IgzTreeNode child in node.Children)
            {
                if (!child.Parents.Contains(node))
                {
                    child.Parents.Add(node);
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

            if (node != null) SelectChildNode(node);
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
        /// Add an object to the tree and to the igz file
        /// </summary>
        public IgzTreeNode Add(igObject obj)
        {
            // Add the object to the igz
            Renderer.Igz.Objects.Add(obj);

            // Create a new node for the object
            IgzTreeNode newNode = new IgzTreeNode(obj);

            // Add the node to the tree
            return Add(newNode, obj);
        }

        public IgzTreeNode Add(IgzTreeNode newNode, igObject obj)
        {
            // Update parents
            foreach (IgzTreeNode node in ObjectNodes)
            {
                if (node.Object!.GetChildren().Contains(obj) && !node.Children.Contains(newNode))
                {
                    node.Children.Add(newNode);
                    newNode.Parents.Add(node);
                    newNode.InitialParentCount++;
                }
            }
            
            AllNodes.Add(newNode);
            ObjectNodes.Add(newNode);

            if (newNode.Parents.Count == 0)
            {
                // Add the node to corresponding root folder
                bool foundParent = false;
                foreach (IgzTreeNode rootNode in _rootNodes.ToList())
                {
                    if (rootNode.Name.StartsWith(obj.GetType().Name))
                    {
                        rootNode.Children.Add(newNode);
                        rootNode.UpdateFolderName();
                        foundParent = true;
                        break;
                    }
                }
                // If no parent was found, create a new root folder
                if (!foundParent)
                {
                    _rootNodes.Add(new IgzTreeNode($"{obj.GetType().Name} (1)", [ newNode ]));
                }
            }            
            
            // Update children
            RebuildNode(newNode);

            // Update the renderer
            Renderer.SetUpdated(obj);

            return newNode;
        }

        /// <summary>
        /// Remove a node from the tree and igz
        /// </summary>
        public void Remove(IgzTreeNode toRemove, bool recursive = true, bool updateRenderer = true)
        {
            if (toRemove.Object == null) return;

            // Remove object from igz
            if (Renderer.Igz.Objects.Remove(toRemove.Object) && updateRenderer)
            {
                Renderer.SetUpdated(toRemove.Object);
            }

            // Remove node from tree
            AllNodes.Remove(toRemove);
            ObjectNodes.Remove(toRemove);

            // Remove node from parents
            foreach (IgzTreeNode rootNode in _rootNodes.ToList())
            {
                if (rootNode.Children.Remove(toRemove))
                {
                    if (rootNode.Children.Count == 0)
                    {
                        _rootNodes.Remove(rootNode);
                    }
                    else
                    {
                        rootNode.UpdateFolderName();
                    }
                }
            }

            // Remove unreferenced child nodes
            if (recursive)
            {
                foreach (IgzTreeNode child in toRemove.Children.ToList())
                {
                    child.Parents.Remove(toRemove);

                    if (child.Parents.Count == 0)
                    {
                        Remove(child, recursive);
                    }
                }
            }
        }

        public override void RemoveUnreferencedNodes()
        {
            foreach (IgzTreeNode node in ObjectNodes.ToList())
            {
                if (node.Parents.Count == 0 && node.InitialParentCount > 0)
                {
                    Remove(node, updateRenderer: false);
                }
            }
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

            foreach (IgzTreeNode node in _rootNodes.ToList())
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