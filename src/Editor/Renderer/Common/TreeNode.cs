using ImGuiNET;

namespace NST
{
    public enum NextFocusState { None, Focus, FocusAndKeyboard }
    public enum NextOpenState { None, Open, Close, ForceOpen, ForceClose }

    /// <summary>
    /// Base class for all tree nodes (IgArchiveTreeNode, IgzTreeNode and HavokTreeNode)
    /// </summary>
    public abstract class TreeNode
    {
        public string Name { get; set; } = ""; // Display name
        public string NodePath { get; set; } = ""; // Unique node path
        public List<TreeNode> Children { get; protected set; } = []; // Child nodes

        // State
        public int TypeCount { get; set; } = 0;
        public bool IsFolder { get; protected set; } = false;
        public bool IsSearchResult { get; set; } = false;
        public bool IsUpdated { get; set; } = false;
        public bool IsOpen { get; protected set; } = false;
        public NextOpenState NextOpen = NextOpenState.None;
        public NextFocusState NextFocus = NextFocusState.None;

        /// <summary>
        /// Returns the node's display name
        /// </summary>
        public virtual string GetDisplayName() => Name;

        /// <summary>
        /// Renders the fields of the object associated with this node
        /// </summary>
        public virtual void RenderObjectView(FileRenderer renderer) { }

        /// <summary>
        /// Sets up the node before rendering:
        /// - Sets node render flags
        /// - Handles focus
        /// - Handles search
        /// - Handles collapse
        /// </summary>
        /// <returns>The node flags, or null if the node should not be rendered</returns>
        protected ImGuiTreeNodeFlags? SetupNode(
            ITreeView tree, 
            bool recursion = false, 
            bool defaultOpen = false, 
            Action? onFocus = null,
            ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.SpanFullWidth)
        {
            // Leaf node (no children)
            if (Children.Count == 0 || recursion)
            {
                flags |= ImGuiTreeNodeFlags.Leaf;
            }

            // Default open node
            else if (defaultOpen)
            {
                flags |= ImGuiTreeNodeFlags.DefaultOpen;
            }

            // Selected node
            if (tree.SelectedNode == this)
            {
                flags |= ImGuiTreeNodeFlags.Selected;

                if (NextFocus != NextFocusState.None && NodePath == tree.SelectedNodePath)
                {
                    if (NextFocus == NextFocusState.FocusAndKeyboard)
                        ImGui.SetKeyboardFocusHere();

                    if (!ImGuiUtils.IsNodeVisible())
                        ImGui.SetScrollHereY();

                    if (onFocus != null) onFocus();

                    NextFocus = NextFocusState.None;
                }
            }

            // Handle search
            if (tree.IsSearchActive && !IsSearchResult)
            {
                return null;
            }

            // Handle open/collapse
            HandleNextItemOpen(tree);

            return flags;
        }

        /// <summary>
        /// Handles opening or collapsing the node
        /// </summary>
        private void HandleNextItemOpen(ITreeView tree)
        {
            if (NextOpen == NextOpenState.None) return;

            if (NextOpen == NextOpenState.ForceOpen || NextOpen == NextOpenState.ForceClose)
            {
                ImGui.SetNextItemOpen(NextOpen == NextOpenState.ForceOpen);
            }
            else if (NodePath == tree.SelectedNodePath)
            {
                ImGui.SetNextItemOpen(NextOpen == NextOpenState.Open);
            }
            else return;

            NextOpen = NextOpenState.None;
        }

        /// <summary>
        /// Handles keyboard navigation and node selection
        /// </summary>
        protected void HandleNavigation(ITreeView tree, bool selectOnClick = true)
        {
            if (tree.SelectNextNode || (selectOnClick && ImGui.IsItemClicked()))
            {
                tree.SetSelectedNode(this);
                tree.SelectNextNode = false;
            }
            else if (NodePath == tree.SelectedNodePath && ImGui.IsItemFocused())
            {
                if (ImGui.IsKeyPressed(ImGuiKey.UpArrow) && tree.PreviousNode != null) tree.SetSelectedNode(tree.PreviousNode);
                else if (ImGui.IsKeyPressed(ImGuiKey.DownArrow)) tree.SelectNextNode = true;
                else if (ImGui.IsKeyPressed(ImGuiKey.LeftArrow) && IsOpen) NextOpen = NextOpenState.Close;
                else if (ImGui.IsKeyPressed(ImGuiKey.RightArrow) && !IsOpen) NextOpen = NextOpenState.Open;
            }
        }

        /// <summary>
        /// Highlights part of a string in yellow
        /// </summary>
        /// <param name="text">The full text</param>
        /// <param name="searchQuery">The string to highlight</param>
        /// <param name="onlyFirstMatch">Whether to highlight subsequent matches</param>
        protected static void HighlightText(string text, string searchQuery, bool onlyFirstMatch = false)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(searchQuery))
                return;

            ImDrawListPtr drawList = ImGui.GetWindowDrawList();
            System.Numerics.Vector2 cursorStart = ImGui.GetCursorScreenPos();
            float highlightWidth = ImGui.CalcTextSize(searchQuery).X;
            float fontSize = ImGui.GetFontSize();

            while (text.Length > 0)
            {
                // Find the next occurrence of the search query
                int nextMatchIndex = text.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase);
                if (nextMatchIndex == -1)
                    break;

                // Calculate the size of text before the highlight
                string preHighlight = text.Substring(0, nextMatchIndex);
                float preHighlightWidth = ImGui.CalcTextSize(preHighlight).X;
                
                // Add yellow highlight
                cursorStart.X += preHighlightWidth;
                drawList.AddRectFilled(cursorStart, cursorStart + new System.Numerics.Vector2(highlightWidth, fontSize), 0x7f00ffff);
                cursorStart.X += highlightWidth;

                text = text.Substring(nextMatchIndex + searchQuery.Length);

                if (onlyFirstMatch)
                    break;
            }
        }
    }
}