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

            _uuid = ImGuiUtils.Uuid();
        }

        /// <summary>
        /// Setup and render the node and its children
        /// </summary>
        /// <param name="renderer">The parent renderer</param>
        /// <param name="tree">The parent tree</param>
        /// <param name="openOnSingleChild">Automatically opens the node if it has only one child</param>
        public void Render(IgArchiveRenderer renderer, IgArchiveTreeView tree, bool defaultOpen = false)
        {
            defaultOpen = defaultOpen || NodePath == "maps/" || (NodePath.StartsWith("maps/") && Children.Count < 3);

            // Setup node
            ImGuiTreeNodeFlags? flags = SetupNode(tree, false, defaultOpen, () => OnFocus(renderer), ImGuiTreeNodeFlags.SpanFullWidth);

            if (flags == null) return;

            // Render item
            RenderNode(tree, flags.Value);

            tree.PreviousNode = this; // Used for keyboard navigation
            
            // Render children
            if (IsOpen)
            {
                bool openChildNode = Children.Count == 1;

                foreach (IgArchiveTreeNode child in Children.ToList())
                {
                    child.Render(renderer, tree, openChildNode);
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
            if (File == null) flags &= ~ImGuiTreeNodeFlags.Leaf;

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
                else if (ImGui.BeginPopupContextItem("ArchiveFileActions" + _uuid))
                {
                    tree.Renderer.RenderNodePopup(File);
                    ImGui.EndPopup();
                }
            }
            else if (ImGui.BeginPopupContextItem("ArchiveFolderActions" + _uuid))
            {
                RenderContextMenu(tree);
                ImGui.EndPopup();
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

            if (File == null) displayName += "/";

            bool excludeFromPkg = (File != null && !File.GetPath().StartsWith("packages/") && !tree.Renderer.IncludeInPackageFile(File));

            if (excludeFromPkg)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff7f7f7f);
            }

            if (isUpdated)
            {
                displayName = "*" + displayName;
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff0099ff);
            }

            ImGui.Text(displayName);
            
            if (isUpdated) ImGui.PopStyleColor();
            if (excludeFromPkg) ImGui.PopStyleColor();
        }

        private void RenderContextMenu(IgArchiveTreeView tree)
        {
            if (ImGui.Selectable("New file..."))
            {
                ModalRenderer.ShowRenameModal("name.igz", (fileName) => 
                {
                    if (!fileName.Contains("."))
                    {
                        fileName += ".igz";
                    }
                    else if (!fileName.EndsWith(".igz") && !fileName.EndsWith(".lng"))
                    {
                        ModalRenderer.ShowMessageModal("Error", "Invalid extension: ." + fileName.Split('.')[1]);
                        return;
                    }
                    
                    string path = NodePath + fileName;

                    IgzFile igz = new IgzFile(path);
                    IgArchiveFile file = new IgArchiveFile(path);
                    file.SetData(igz.Save());

                    tree.Renderer.AddFile(file);
                    tree.SetSelectedNode(tree.FindNode(file));
                });
            }
            if (ImGui.Selectable("New folder..."))
            {
                ModalRenderer.ShowRenameModal(NodePath, (folderPath) => 
                {
                    if (!folderPath.EndsWith("/")) folderPath += "/";
                    IgArchiveFile newFolder = new IgArchiveFile(folderPath);
                    tree.AddFile(newFolder);
                });
            }
            if (Children.Count == 0 && ImGui.Selectable("Delete folder"))
            {
                tree.RemoveFile(this);
            }
        }
    }
}