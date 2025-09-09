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

        public override HavokTreeNode FindNode(object obj)
        {
            return TreeView.AllNodes.Values.First(e => e.Object == obj)!;
        }
        
        public override List<string> FindDerivedObjectNames(Type type, object? current, out int currentIndex)
        {
            List<string> names = [];

            currentIndex = 0;
            
            foreach (HavokTreeNode node in TreeView.AllNodes.Values)
            {
                if (node.Object.GetType().IsAssignableTo(type))
                {
                    if (node.Object == current)
                    {
                        currentIndex = names.Count;
                    }
                    names.Add(node.GetDisplayName()!);
                }
            }

            return names;
        }
    }
}