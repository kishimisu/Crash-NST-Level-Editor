using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbVariableBindingSetBinding : hkObject
    {
        public override uint Hash => 0x4d592f72;

        [FieldAttr(0)] public string _memberPath; // TYPE_STRINGPTR
        [FieldAttr(8)] public u32 _memberClass; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(16)] public i32 _offsetInObjectPlusOne; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(20)] public i32 _offsetInArrayPlusOne; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(24)] public i32 _rootVariableIndex; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(28)] public i32 _variableIndex; // TYPE_INT32
        [FieldAttr(32)] public i8 _bitIndex; // TYPE_INT8
        [FieldAttr(33)] public EBindingType _bindingType; // TYPE_ENUM, etype: BindingType, subtype: TYPE_INT8
        [FieldAttr(34)] public u8 _memberType; // TYPE_ENUM, subtype: TYPE_UINT8, flags: SERIALIZE_IGNORED
        [FieldAttr(35)] public i8 _variableType; // TYPE_INT8, flags: SERIALIZE_IGNORED
        [FieldAttr(36)] public i8 _flags; // TYPE_FLAGS, subtype: TYPE_INT8, flags: SERIALIZE_IGNORED
    }
}