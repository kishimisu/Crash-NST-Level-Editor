using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkRefCountedPropertiesEntry : hkObject
    {
        public override uint Hash => 0x28ef93ed;

        [FieldAttr(0)] public hkReferencedObject _object; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
        [FieldAttr(8)] public u16 _key; // TYPE_UINT16
        [FieldAttr(10)] public u16 _flags; // TYPE_UINT16
    }
}