using ImGuiNET;

namespace NST
{
    public interface ITreeView
    {
        public TreeNode? PreviousNode { get; }
        public TreeNode? SelectedNode { get; }
        public string SelectedNodePath { get; }
        public bool IsSearchActive { get; }
        public bool SelectNextNode { get; set; }

        public void Render();
        public void RenderObjectView(FileRenderer renderer);

        public bool ExpandParents(TreeNode toFind);
        public void SetSelectedNode(TreeNode? node, bool expandParents = false, bool keyboardFocus = true);
    }

    /// <summary>
    /// Base class for all tree views (IgArchiveTreeView, IgzTreeView and HavokTreeView)
    /// </summary>
    public abstract class TreeView<T> : ITreeView where T : TreeNode
    {
        // Nodes
        public Dictionary<string, T> AllNodes { get; protected set; } = []; // All nodes (objects + folders)
        protected List<T> _rootNodes = []; // Root object nodes
        public T? SelectedNode { get; private set; } = null; // Currently selected node (can appear multiple times in the tree)
        public string SelectedNodePath { get; set; } = ""; // Unique path to the currently selected node

        // Search
        public string SearchQuery = ""; // Current search query
        public bool IsSearchActive => SearchQuery != "";

        private bool _expandAll = false;
        protected Dictionary<T, bool> _expandedStates = [];

        // Navigation
        private HistoryManager<T> _nodeHistory = new HistoryManager<T>(); // History of focused nodes
        public T? PreviousNode { get; set; } = null; // The previous node in the tree
        public bool SelectNextNode { get; set; } = false; // Whether to select the next node in the tree after rendering the current one

        // Interface
        TreeNode? ITreeView.SelectedNode => SelectedNode;
        TreeNode? ITreeView.PreviousNode => PreviousNode;
        void ITreeView.SetSelectedNode(TreeNode? node, bool expandParents, bool keyboardFocus) => SetSelectedNode((T?)node, expandParents, keyboardFocus);

        /// <summary>
        /// Render the tree
        /// </summary>
        public abstract void Render();

        /// <summary>
        /// Rebuild the tree
        /// </summary>
        protected virtual void RebuildTree() { }

        /// <summary>
        /// Sets the currently focused node and add it to the history.
        /// </summary>
        /// <param name="node">The node to select</param>
        /// <param name="expandParents">Whether to expand the parents of the selected node</param>
        /// <param name="keyboardFocus"></param>
        public void SetSelectedNode(T? node, bool expandParents = false, bool keyboardFocus = true)
        {
            SelectedNode = node;
            SelectedNodePath = node?.NodePath ?? "";

            if (node == null) {
                return;
            }

            node.NextFocus = keyboardFocus ? NextFocusState.FocusAndKeyboard : NextFocusState.Focus;

            if (expandParents)
            {
                ExpandParents(node);
            }

            if (!node.IsFolder)
            {
                _nodeHistory.Add(node);
            }
        }

        /// <summary>
        /// Updates the visible nodes based on the current search query
        /// </summary>
        protected void UpdateSearch()
        {
            // Search started
            if (_expandedStates.Count == 0 && IsSearchActive)
            {
                foreach (T node in AllNodes.Values)
                {
                    _expandedStates.Add(node, node.IsOpen);
                    node.NextOpen = NextOpenState.ForceOpen;
                }
                FilterNodes(_rootNodes, []);
            }
            // Search cleared
            else if (_expandedStates.Count > 0 && !IsSearchActive)
            {
                foreach (T node in AllNodes.Values)
                {
                    if (_expandedStates.TryGetValue(node, out bool isOpen))
                    {
                        node.NextOpen = isOpen ? NextOpenState.ForceOpen : NextOpenState.ForceClose;
                    }
                }
                _expandedStates.Clear();
                FilterNodes(_rootNodes, []);

                SetSelectedNode(SelectedNode, true, false);
            }
            // Search active
            else if (IsSearchActive)
            {
                FilterNodes(_rootNodes, []);
            }
        }

        /// <summary>
        /// Filters the nodes recursively based on the current search query
        /// </summary>
        private bool FilterNodes(List<T> nodes, HashSet<T> exploredNodes)
        {
            bool anyMatch = false;

            foreach (T node in nodes)
            {
                if (exploredNodes.Contains(node)) continue;
                exploredNodes.Add(node);

                bool matchSearch = FilterNodes(node.Children.Cast<T>().ToList(), exploredNodes) || 
                                   ( IsSearchActive
                                        ? node.GetDisplayName()?.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase ) == true
                                        : node == SelectedNode );

                node.IsSearchResult = matchSearch;
                anyMatch |= matchSearch;
            }

            return anyMatch;
        }

        /// <summary>
        /// Expands the parents of a node
        /// </summary>
        public bool ExpandParents(TreeNode toFind) => ExpandParents((T)toFind);
        public bool ExpandParents(T toFind) => ExpandParents(toFind, _rootNodes, new HashSet<T>());
        private bool ExpandParents(T toFind, List<T> nodes, HashSet<T> exploredNodes)
        {
            foreach (T node in nodes)
            {
                if (node == toFind) return true;
                if (exploredNodes.Contains(node)) continue;

                exploredNodes.Add(node);

                if (ExpandParents(toFind, node.Children.Cast<T>().ToList(), exploredNodes))
                {
                    node.NextOpen = NextOpenState.ForceOpen;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Try to expand root nodes if not already expanded,
        /// otherwise expand/collapse all nodes.
        /// </summary>
        private void OnClickExpandAll()
        {
            // Expand root nodes
            if (!_expandAll && _rootNodes.Any(n => !n.IsOpen))
            {
                foreach (TreeNode node in _rootNodes)
                {
                    node.NextOpen = NextOpenState.ForceOpen;
                }
            }
            // Expand/collapse all nodes
            else
            {
                _expandAll = !_expandAll;

                foreach (TreeNode node in AllNodes.Values)
                {
                    node.NextOpen = _expandAll ? NextOpenState.ForceOpen : NextOpenState.ForceClose;
                }
            }
        }

        /// <summary>
        /// Renders the object view for the currently selected node
        /// </summary>
        /// <param name="renderer">Parent file renderer</param>
        public void RenderObjectView(FileRenderer renderer)
        {
            if (SelectedNode != null)
            {
                SelectedNode.RenderObjectView(renderer);
            }
        }

        /// <summary>
        /// Renders the expand all button
        /// </summary>
        protected void RenderExpandAll()
        {
            if (ImGui.Button(_expandAll ? "Collapse All" : "Expand All"))
            {
                OnClickExpandAll();
            }
        }

        /// <summary>
        /// Renders the search bar
        /// </summary>
        protected void RenderSearchBar(bool sameLine = true)
        {
            if (sameLine) ImGui.SameLine();
            ImGui.PushItemWidth(-1);
            ImGui.InputTextWithHint("##Search" + GetHashCode(), "Search...", ref SearchQuery, 256);
            ImGui.PopItemWidth();
        }
        
        /// <summary>
        /// Renders the history arrows
        /// </summary>
        public void RenderHistoryArrows()
        {
            if (!_nodeHistory.HasPrevious()) ImGui.BeginDisabled();
            ImGui.Text("<"); 
            ImGui.SameLine();
            if (ImGui.IsItemHovered())
            {
                ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                if (ImGui.IsMouseClicked(ImGuiMouseButton.Left))
                {
                    SetSelectedNode(_nodeHistory.GetPrevious(), true);
                }
            }
            if (!_nodeHistory.HasPrevious()) ImGui.EndDisabled();

            if (!_nodeHistory.HasNext()) ImGui.BeginDisabled();
            ImGui.Text(">"); 
            ImGui.SameLine();
            if (ImGui.IsItemHovered())
            {
                ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                if (ImGui.IsMouseClicked(ImGuiMouseButton.Left))
                {
                    SetSelectedNode(_nodeHistory.GetNext(), true);
                }
            }
            if (!_nodeHistory.HasNext()) ImGui.EndDisabled();
        }
    }

    /// <summary>
    /// Manages the history of selected nodes to allow previous/next navigation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HistoryManager<T> where T : notnull
    {
        private List<T> _history = [];
        private int _current = -1;

        public bool HasPrevious() => _current > 0;
        public bool HasNext() => _current < _history.Count - 1;

        public void Add(T item)
        {
            if (_history.Count > 0 && item.Equals(_history[_current])) return;

            if (_current != _history.Count - 1)
            {
                _history.RemoveRange(_current + 1, _history.Count - _current - 1);
            }

            _current = _history.Count;

            _history.Add(item);
        }

        public T? GetPrevious()
        {
            if (_current > 0)
            {
                _current -= 1;
                return _history[_current];
            }

            return default;
        }

        public T? GetNext()
        {
            if (_current < _history.Count - 1)
            {
                _current += 1;
                return _history[_current];
            }

            return default;
        }
    }
}