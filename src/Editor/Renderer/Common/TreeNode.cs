using ImGuiNET;

namespace NST
{
    public enum NextFocusState { None, Focus, FocusAndKeyboard };

    /// <summary>
    /// Base class for all tree nodes (IgArchiveTreeNode, IgzTreeNode and HavokTreeNode)
    /// </summary>
    public abstract class TreeNode
    {
        public string Name { get; set; } = ""; // Display name
        public List<TreeNode> Children { get; protected set; } = []; // Child nodes

        // State
        public int TypeCount { get; set; } = 0;
        public bool IsSearchResult { get; set; } = false;
        public bool IsUpdated { get; set; } = false;
        public bool IsOpen { get; protected set; } = false;
        public bool? NextOpen = null;
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