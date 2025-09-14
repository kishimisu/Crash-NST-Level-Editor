using Alchemy;
using Havok;

namespace NST
{
    /// <summary>
    /// Handles rendering of Havok files
    /// </summary>
    public class HavokRenderer : FileRenderer
    {
        private HavokFile _havokFile; // Current file being rendered

        public override HavokTreeView TreeView { get; } = new HavokTreeView(); // hkObject tree

        public override byte[] SaveFile() => _havokFile.Save();
        public override void ReloadFile() => SetFile(ArchiveFile.ToHavokFile());

        public HavokRenderer(HavokFile file, IgArchiveFile archiveFile, IgArchiveRenderer archiveRenderer)
        {
            ArchiveFile = archiveFile;
            ArchiveRenderer = archiveRenderer;
            SetFile(file);
        }

        /// <summary>
        /// Sets the current Havok file and rebuilds the tree
        /// </summary>
        private void SetFile(HavokFile havokFile)
        {
            _havokFile = havokFile;

            TreeView.BuildNodes(havokFile.RootLevelContainer);
        }

        public override void SetUpdated(object? obj = null)
        {
            obj ??= TreeView.SelectedNode?.Object;

            // Update archive
            base.SetUpdated(obj);

            // Update tree view
            if (obj is hkObject hkObj)
            {
                TreeView.SetNodeUpdated(hkObj);
            }
        }

        public override void OnObjectRefChanged()
        {
            SetUpdated();
            TreeView.RebuildNode(TreeView.SelectedNode);
        }

        public override HavokTreeNode? FindNode(object obj)
        {
            return TreeView.AllNodes.First(e => e.Object == obj);
        }
        
        public override List<TreeNode> FindDerivedObjectNodes(Type type, object? current, out int currentIndex)
        {
            List<TreeNode> nodes = [];

            currentIndex = 0;
            
            foreach (HavokTreeNode node in TreeView.AllNodes)
            {
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