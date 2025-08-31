using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hknpShapeTagCodec : hkReferencedObject
    {
        public override uint Hash => 0x85b7c832;

        [FieldAttr(16)] public EType _type; // TYPE_ENUM, etype: Type, subtype: TYPE_UINT8
    }
}