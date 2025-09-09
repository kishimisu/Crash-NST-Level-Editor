using Alchemy;
using Havok;

namespace NST
{
    /// <summary>
    /// Tree of Havok objects
    /// </summary>
    public class HavokTreeView : TreeView<HavokTreeNode>
    {
        /// <summary>
        /// Build the tree from the file's root level container
        /// </summary>
        public void BuildNodes(hkObject rootLevelContainer)
        {
            Dictionary<hkObject, HavokTreeNode> nodes = [];

            Queue<hkObject> queue = new Queue<hkObject>([ rootLevelContainer ]);

            while (queue.Count > 0)
            {
                hkObject obj = queue.Dequeue();
                if (nodes.ContainsKey(obj)) continue;

                string name = obj.GetType().Name + "_" + obj.GetHashCode();
                HavokTreeNode node = new HavokTreeNode(obj);
                nodes.Add(obj, node);

                foreach (hkObject child in obj.GetChildren())
                {
                    queue.Enqueue(child);
                }
            }

            foreach ((hkObject obj, HavokTreeNode node) in nodes)
            {
                foreach (hkObject child in obj.GetChildren())
                {
                    if (!nodes.ContainsKey(child)) continue;
                    
                    HavokTreeNode childNode = nodes[child];
                    node.Children.Add(childNode);
                }
            }

            _rootNodes = nodes.Values.Take(1).ToList();

            var typeCount = new Dictionary<Type, int>();

            foreach ((hkObject obj, HavokTreeNode node) in nodes)
            {
                foreach (CachedFieldAttr field in obj.GetFields())
                {
                    if (field.GetName() == "_name" && field.GetFieldType() == typeof(string))
                    {
                        string? name = (string?)field.GetValue(obj);
                        if (name != null) {
                            node.Name = name;
                            break;
                        }
                    }
                }

                Type type = obj.GetType();
                typeCount[type] = typeCount.GetValueOrDefault(type) + 1;
                node.TypeCount = typeCount[type];
            }

            foreach (HavokTreeNode node in nodes.Values)
            {
                if (typeCount[node.Object.GetType()] <= 1)
                {
                    node.TypeCount = 0;
                }
            }

            AllNodes = nodes.Select(kvp => (kvp.Value.GetDisplayName(), kvp.Value)).ToDictionary();
        }

        public override void Render()
        {
            RenderExpandAll();
            RenderSearchBar();

            UpdateSearch();

            PreviousNode = null;

            foreach (HavokTreeNode node in _rootNodes)
            {
                node.Render(this, []);
            }
        }
    }
}