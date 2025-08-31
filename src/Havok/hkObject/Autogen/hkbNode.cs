using Alchemy;

namespace Havok
{
    [ObjectAttr(80)]
    public class hkbNode : hkbBindable
    {
        public override uint Hash => 0x8b4251f;

        [FieldAttr(48)] public u64 _userData; // TYPE_ULONG
        [FieldAttr(56)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(64)] public u16 _id; // TYPE_UINT16, flags: SERIALIZE_IGNORED
        [FieldAttr(66)] public i8 _cloneState; // TYPE_ENUM, subtype: TYPE_INT8, flags: SERIALIZE_IGNORED
        [FieldAttr(67)] public u8 _type; // TYPE_ENUM, subtype: TYPE_UINT8, flags: SERIALIZE_IGNORED
        [FieldAttr(72)] public u32 _nodeInfo; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}