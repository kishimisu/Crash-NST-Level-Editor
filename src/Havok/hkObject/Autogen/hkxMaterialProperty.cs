using Alchemy;

namespace Havok
{
    [ObjectAttr(8)]
    public class hkxMaterialProperty : hkObject
    {
        public override uint Hash => 0xd295234d;

        [FieldAttr(0)] public u32 _key; // TYPE_UINT32
        [FieldAttr(4)] public u32 _value; // TYPE_UINT32
    }
}