using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hknpCollisionFilter : hkReferencedObject
    {
        public override uint Hash => 0x1c7179c4;

        [FieldAttr(16)] public EType _type; // TYPE_ENUM, etype: Type, subtype: TYPE_UINT8
    }
}