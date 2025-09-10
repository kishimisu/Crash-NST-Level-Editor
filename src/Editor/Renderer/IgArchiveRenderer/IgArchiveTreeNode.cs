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

        public IgArchiveTreeNode(string path, IgArchiveFile? file = null, bool folderNode = false)
        {
            File = file;
            NodePath = path;
            IsFolder = folderNode;

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
            bool defaultOpen = openOnSingleChild || NodePath.StartsWith("maps/");
            
            // Setup node
            ImGuiTreeNodeFlags? flags = SetupNode(tree, false, defaultOpen, () => OnFocus(renderer), ImGuiTreeNodeFlags.SpanFullWidth);

            if (flags == null) return;

            // Render item
            RenderNode(tree, flags.Value);

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
        private void RenderNode(IgArchiveTreeView tree, ImGuiTreeNodeFlags flags)
        {
            // Create the tree node with no name
            IsOpen = ImGui.TreeNodeEx("##" + GetHashCode(), flags);
            
            // Handle tree node events
            HandleItemEvents(tree);

            // Render custom name
            ImGui.SameLine();
            RenderName(tree);
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
            HandleNavigation(tree, false);

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

        private void OnFocus(IgArchiveRenderer renderer)
        {
            if (File != null)
            {
                renderer.FocusNode(this, force: true);
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