using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Represents a node in the igArchive tree.
    /// Leaf nodes contain an IgArchiveFile while other nodes are folders.
    /// </summary>
    public class IgArchiveTreeNode : TreeNode
    {
        public IgArchiveFile? File { get; } = null; // Corresponding file, null for folders
        public string NodePath { get; } = ""; // File or folder path

        public IgArchiveTreeNode(string path, IgArchiveFile? file = null)
        {
            File = file;
            NodePath = path;

            Name = path.EndsWith("/") 
                ? Path.GetFileName(path.Substring(0, path.Length - 1))
                : Path.GetFileName(path);
        }

        /// <summary>
        /// Setup and render the node and its children
        /// </summary>
        /// <param name="renderer">The parent renderer</param>
        /// <param name="tree">The parent tree</param>
        /// <param name="openOnSingleChild">Automatically opens the node if it has only one child</param>
        public void Render(IgArchiveRenderer renderer, IgArchiveTreeView tree, bool openOnSingleChild = false)
        {
            tree.CheckNextNode(this); // Handle keyboard navigation down

            // Setup flags
            ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanFullWidth;

            if (Children.Count == 0)
            {
                flags |= ImGuiTreeNodeFlags.Leaf;
            }
            else if (Children.Count == 1 && openOnSingleChild || NodePath.StartsWith("maps/"))
            {
                flags |= ImGuiTreeNodeFlags.DefaultOpen;
            }
            if (tree.SelectedNode == this)
            {
                flags |= ImGuiTreeNodeFlags.Selected;

                // Handle next focus
                if (NextFocus != NextFocusState.None)
                {
                    if (NextFocus == NextFocusState.FocusAndKeyboard)
                        ImGui.SetKeyboardFocusHere();

                    if (!ImGuiUtils.IsNodeVisible())
                    {
                        ImGui.SetScrollHereY();
                    }

                    if (File != null)
                    {
                        renderer.FocusNode(this);
                    }

                    NextFocus = NextFocusState.None;
                }
            }

            // Handle search
            if (tree.IsSearchActive() && !IsSearchResult)
            {
                return;
            }
            if (NextOpen != null)
            {
                ImGui.SetNextItemOpen((bool)NextOpen);
                NextOpen = null;
            }

            // Render item
            IsOpen = RenderNode(tree, flags);

            tree.PreviousNode = this; // Used for keyboard navigation
            
            // Render children
            if (IsOpen)
            {
                bool hasOnlyOneChild = Children.Count == 1;

                foreach (IgArchiveTreeNode child in Children.ToList())
                {
                    child.Render(renderer, tree, hasOnlyOneChild);
                }

                ImGui.TreePop();
            }
        }

        /// <summary>
        /// Render the node
        /// </summary>
        /// <returns>True if the node is currently open</returns>
        private bool RenderNode(IgArchiveTreeView tree, ImGuiTreeNodeFlags flags)
        {
            // Create the tree node with no name
            bool isOpen = ImGui.TreeNodeEx("##" + GetHashCode(), flags);
            
            // Handle tree node events
            HandleItemEvents(tree);

            // Render custom name
            ImGui.SameLine();
            RenderName(tree);

            return isOpen;
        }

        /// <summary>
        /// Handle all events associated to the tree node
        /// </summary>
        private void HandleItemEvents(IgArchiveTreeView tree)
        { 
            if (File != null)
            {
                // Left click (open file)
                if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
                {
                    tree.Renderer.FocusNode(this);
                }
                // Right-click (context menu)
                else if (ImGui.BeginPopupContextItem("ArchiveFileActions"))
                {
                    tree.Renderer.RenderNodePopup(File);
                    ImGui.EndPopup();
                }
            }

            // Keyboard navigation
            if (ImGui.IsItemFocused())
            {
                if (ImGui.IsKeyPressed(ImGuiKey.UpArrow)) tree.SetSelectedNode(tree.PreviousNode);
                else if (ImGui.IsKeyPressed(ImGuiKey.DownArrow)) tree.SelectNextNode = true;
                else if (ImGui.IsKeyPressed(ImGuiKey.LeftArrow) && IsOpen) NextOpen = false;
                else if (ImGui.IsKeyPressed(ImGuiKey.RightArrow) && !IsOpen) NextOpen = true;
            }

            if (File != null)
            {
                // Files act as drag sources
                tree.BeginDragDropSource(this);
            }
            else
            {
                // Folders act as drag targets
                tree.BeginDragDropTarget(this);
            }
        }

        /// <summary>
        /// Render the name of the node.
        /// Will highlight the search query and draw a "*" next to the name if the file is updated
        /// </summary>
        private void RenderName(IgArchiveTreeView tree)
        {
            bool isUpdated = File != null && tree.Renderer.FileManager.IsFileUpdated(File);

            HighlightText(Name, tree.SearchQuery);

            string displayName = Name;

            if (isUpdated)
            {
                displayName = "*" + displayName;
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff0099ff);
            }

            ImGui.Text(displayName);
            
            if (isUpdated) ImGui.PopStyleColor();
        }
    }
}