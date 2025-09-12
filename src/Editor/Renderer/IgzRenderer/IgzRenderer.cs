using Alchemy;

namespace NST
{
    /// <summary>
    /// Handles rendering of IGZ files
    /// </summary>
    public class IgzRenderer : FileRenderer
    {
        public IgzFile Igz { get; private set; } // Current file being rendered

        public override IgzTreeView TreeView { get; } = new IgzTreeView(); // igObject tree

        public override byte[] SaveFile() => Igz.Save();
        public override void ReloadFile() => SetIgz(ArchiveFile.ToIgzFile());

        public IgzRenderer(IgzFile igz, IgArchiveFile archiveFile, IgArchiveRenderer archiveRenderer)
        {
            ArchiveFile = archiveFile;
            ArchiveRenderer = archiveRenderer;
            SetIgz(igz);
        }

        /// <summary>
        /// Sets the current IGZ file.
        /// Also rebuilds the tree and preview manager.
        /// </summary>
        private void SetIgz(IgzFile igz)
        {
            // Create the tree view
            Igz = igz;
            TreeView.SetIgz(igz);

            try
            {
                // Create the preview manager
                _previewManager = new IgzPreviewManager(this);
                if (!_previewManager.IsActive()) _previewManager = null;
            }
            catch (Exception e)
            {
                _previewManager = null;
                Console.WriteLine($"WARNING: Failed to create preview manager: {e.Message}\n{e.StackTrace}");
            }

            if (_previewManager == null || !_previewManager.IsActiveInObjectView())
            {
                // Auto focus root node
                TreeView.SelectRootObject();
            }
        }

        public override void SetUpdated(object? obj = null)
        {
            obj ??= TreeView.SelectedNode?.Object;

            // Update archive
            base.SetUpdated(obj);

            // Update tree view
            if (obj is igObject igObj)
            {
                TreeView.SetNodeUpdated(igObj);
            }
        }

        public override void OnObjectRefChanged()
        {
            SetUpdated();
            TreeView.RebuildNode(Igz, TreeView.SelectedNode);
        }

        public override IgzTreeNode FindNode(object obj)
        {
            return TreeView.ObjectNodes.Find(e => e.Object == obj)!;
        }

        public override List<TreeNode> FindDerivedObjectNodes(Type type, object? current, out int currentIndex)
        {
            List<TreeNode> nodes = [];

            currentIndex = 0;

            foreach (IgzTreeNode node in TreeView.ObjectNodes)
            {
                if (node.Object == null) continue;
                
                if (node.Object.GetType().IsAssignableTo(type))
                {
                    if (node.Object == current)
                    {
                        currentIndex = nodes.Count;
                    }
                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}