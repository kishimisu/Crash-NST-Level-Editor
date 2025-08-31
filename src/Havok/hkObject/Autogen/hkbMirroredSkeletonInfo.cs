using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(64)]
    public class hkbMirroredSkeletonInfo : hkReferencedObject
    {
        public override uint Hash => 0x9f13052e;

        [FieldAttr(16)] public Vector4 _mirrorAxis; // TYPE_VECTOR4
        [FieldAttr(32)] public hkMemory<i16> _bonePairMap; // TYPE_ARRAY, subtype: TYPE_INT16
        [FieldAttr(48)] public hkMemory<i16> _partitionPairMap; // TYPE_ARRAY, subtype: TYPE_INT16
    }
}