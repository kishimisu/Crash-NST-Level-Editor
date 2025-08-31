using Alchemy;

namespace Havok
{
    [ObjectAttr(64)]
    public class hkbBoneWeightArray : hkbBindable
    {
        public override uint Hash => 0x2c9b5751;

        [FieldAttr(48)] public hkMemory<float> _boneWeights; // TYPE_ARRAY, subtype: TYPE_REAL
    }
}