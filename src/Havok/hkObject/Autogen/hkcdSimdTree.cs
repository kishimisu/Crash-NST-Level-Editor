using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkcdSimdTree : hkBaseObject
    {
        public override uint Hash => 0x84c43960;

        [FieldAttr(8)] public hkMemory<hkcdSimdTreeNode> _nodes; // TYPE_ARRAY, ctype: hkcdSimdTreeNode, subtype: TYPE_STRUCT
    }
}