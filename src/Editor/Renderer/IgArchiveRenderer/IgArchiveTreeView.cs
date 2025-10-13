using Alchemy;
using ImGuiNET;
using System.Runtime.InteropServices;

namespace NST
{
    /// <summary>
    /// Tree of igArchive files
    /// </summary>
    public class IgArchiveTreeView : TreeView<IgArchiveTreeNode>
    {
        // Parent archive renderer
        public IgArchiveRenderer Renderer { get; private set; }

        // Drag & drop
        private const string PAYLOAD_IDENTIFIER = "igArchiveFile";
        private static IgArchive? _dragAndDropSource = null;

        public IgArchiveTreeView(IgArchiveRenderer renderer)
        {
            Renderer = renderer;
            BuildTree();
        }

        /// <summary>
        /// Build the tree from the archive
        /// </summary>
        private void BuildTree()
        {
            List<IgArchiveFile> files = Renderer.Archive.GetFiles().ToList();

            files.Sort((f1, f2) => f1.GetPath().CompareTo(f2.GetPath()));

            foreach (IgArchiveFile file in files)
            {
                AddFile(file, false);
            }
        }

        /// <summary>
        /// Add a file to the tree.
        /// Recursively creates parent nodes (folders) if they don't exist.
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="sort">Whether to sort the tree when adding the file</param>
        public void AddFile(IgArchiveFile file, bool sort = true)
        {
            string[] path = file.GetPath().Split('/');
            string nodeIdentifier = "";

            IgArchiveTreeNode? prev = null;

            for (int i = 0; i < path.Length; i++)
            {
                if (i == path.Length - 1 && file.GetPath().EndsWith("/")) break;

                string segment = path[i];
                nodeIdentifier += segment + "/";

                IgArchiveTreeNode? node = AllNodes.FirstOrDefault(n => n.NodePath == nodeIdentifier);

                if (node == null)
                {
                    node = (i < path.Length - 1)
                        ? new (nodeIdentifier, folderNode: true) // Folder node
                        : new (file.GetPath(), file); // Leaf node (file)
                    
                    nodeIdentifier = node.NodePath;

                    if (prev != null)
                        prev.Children.Add(node);
                    else
                        _rootNodes.Add(node);

                    AllNodes.Add(node);

                    if (sort)
                    {
                        prev?.Children.Sort((n1, n2) => n1.GetDisplayName().CompareTo(n2.GetDisplayName()));
                    }
                }

                prev = node;
            }

            if (sort)
            {
                _rootNodes.Sort((n1, n2) => n1.GetDisplayName().CompareTo(n2.GetDisplayName()));
            }
        }

        /// <summary>
        /// Remove the tree node associated to a file.
        /// Recursively remove parent nodes that no longer have any children
        /// </summary>
        public void RemoveFile(IgArchiveFile file)
        {
            IgArchiveTreeNode? node = FindNode(file);

            if (node != null)
            {
                RemoveFile(node);
            }
            else
            {
                Console.WriteLine("Failed to remove file (not found): " + file.GetPath());
            }
        }

        public void RemoveFile(IgArchiveTreeNode? node)
        {
            if (node == null) return;
            
            const int max_parent_depth = 20; // guard infinite loops
            for (int i = 0; i < max_parent_depth; i++)
            {
                AllNodes.Remove(node);
                _rootNodes.Remove(node);

                IgArchiveTreeNode? parent = AllNodes.FirstOrDefault(e => e.Children.Contains(node));

                parent?.Children.Remove(node);
                node = parent;

                if (node == null || node.Children.Count > 0)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Recreate the node associated to a file after its path/name has been changed
        /// </summary>
        public void RefreshFile(IgArchiveFile file)
        {
            RemoveFile(file);
            AddFile(file);
        }

        /// <summary>
        /// Find the tree node associated to a file
        /// </summary>
        public IgArchiveTreeNode? FindNode(IgArchiveFile file)
        {
            return AllNodes.FirstOrDefault(e => e.File == file);
        }

        /// <summary>
        /// Find the tree node associated to a reference (namespace name)
        /// </summary>
        public IgArchiveTreeNode? FindNode(NamedReference reference)
        {
            string namespaceLower = reference.namespaceName.ToLowerInvariant();
            return AllNodes.FirstOrDefault(e => e.File?.GetName(false).ToLowerInvariant() == namespaceLower);
        }

        /// <summary>
        /// Render the tree view
        /// </summary>
        public override void Render()
        {
            // Handle search
            RenderSearchBar(sameLine: false);
            UpdateSearch();

            // Render tree
            if (ImGui.BeginChild("igArchiveTreeView" + GetHashCode(), System.Numerics.Vector2.Zero, ImGuiChildFlags.None, ImGuiWindowFlags.HorizontalScrollbar))
            {
                PreviousNode = null;
                SelectNextNode = false;

                foreach (IgArchiveTreeNode node in _rootNodes.ToList())
                {
                    node.Render(Renderer, this);
                }

                if (_rootNodes.Count == 0)
                {
                    ImGuiUtils.CenteredText("Drag & drop files from other archives here!");
                }
            }
            ImGui.EndChild();

            // Handle drag and drop (from another archive to this one)
            if (_dragAndDropSource != Renderer.Archive)
            {
                BeginDragDropTarget();
            }
        }
        
        /// <summary>
        /// Make the selected node act as a drag and drop source
        /// </summary>
        public void BeginDragDropSource(IgArchiveTreeNode node)
        {
            if (!ImGui.BeginDragDropSource()) return;

            string payloadStr = node.File!.GetPath();
            byte[] payload = System.Text.Encoding.UTF8.GetBytes(payloadStr);
            IntPtr payloadPtr = Marshal.AllocHGlobal(payloadStr.Length);
            Marshal.Copy(payload, 0, payloadPtr, payloadStr.Length);

            try 
            {
                ImGui.SetDragDropPayload(PAYLOAD_IDENTIFIER, payloadPtr, (uint)payload.Length);
            }
            finally 
            {
                Marshal.FreeHGlobal(payloadPtr);
            }

            _dragAndDropSource = Renderer.Archive;

            ImGui.Text(node.Name);
            
            ImGui.EndDragDropSource();
        }
        
        /// <summary>
        /// Make the selected element act as a drag and drop target
        /// </summary>
        /// <param name="node">The node to act as a drag and drop target. If not set, the last ImGUI element will be used</param>
        public void BeginDragDropTarget(IgArchiveTreeNode? node = null)
        {
            if (!ImGui.BeginDragDropTarget())
            {
                return;
            }
            
            var payload = ImGui.AcceptDragDropPayload(PAYLOAD_IDENTIFIER, ImGuiDragDropFlags.AcceptBeforeDelivery | ImGuiDragDropFlags.AcceptNoPreviewTooltip);
            
            unsafe
            {
                if (payload.NativePtr != null)
                {
                    nint payloadData = payload.Data;
                    byte[] data = new byte[payload.DataSize];
                    Marshal.Copy((IntPtr)payload.Data, data, 0, (int)payload.DataSize);
                    string filePath = System.Text.Encoding.UTF8.GetString(data);

                    string action = _dragAndDropSource == Renderer.Archive ? "Move" : "Copy";
                    string destName = node == null ? "here" : "to " + node.Name;
                    
                    ImGui.PushStyleColor(ImGuiCol.PopupBg, new System.Numerics.Vector4(0.1f, 0.1f, 0.1f, 1.5f));
                    ImGui.SetTooltip($"{action} {destName}");
                    ImGui.PopStyleColor();
                    
                    if (payload.IsDelivery())
                    {
                        OnDragDropStop(filePath, node);
                    }
                }
            }

            ImGui.EndDragDropTarget();
        }

        /// <summary>
        /// Handles actions after a drag and drop has stopped
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="targetNode"></param>
        private void OnDragDropStop(string sourceFilePath, IgArchiveTreeNode? targetNode)
        {
            if (_dragAndDropSource == null) return;

            IgArchiveFile? file = _dragAndDropSource.FindFile(sourceFilePath, FileSearchType.Path);

            if (file == null) return;

            // Drag from another archive to the root (copy file)
            if (targetNode == null)
            {
                file = file.Clone();
                AddFile(file);

                Renderer.Archive.AddFile(file);
                Renderer.SetFileUpdated(file, isNewFile: true);
            }
            // Drag from another archive to a folder (copy file)
            else if (_dragAndDropSource != Renderer.Archive)
            {
                string newPath = targetNode.NodePath + file.GetName();
                
                file = file.Clone(newPath);
                AddFile(file);

                Renderer.Archive.AddFile(file);
                Renderer.SetFileUpdated(file, isNewFile: true);
            }
            // Drag from/to the same archive (move file)
            else
            {
                string originalPath = file.GetPath();
                string newPath = targetNode.NodePath + file.GetName();
                
                if (file.GetPath() == newPath) return;
                file.SetPath(newPath);

                RefreshFile(file);

                Renderer.SetFileUpdated(file, originalPath: originalPath);
            }
        }
    }
}