using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbVariableBindingSet : hkReferencedObject
    {
        public override uint Hash => 0xe942f339;

        [FieldAttr(16)] public hkMemory<hkbVariableBindingSetBinding> _bindings; // TYPE_ARRAY, ctype: hkbVariableBindingSetBinding, subtype: TYPE_STRUCT
        [FieldAttr(32)] public i32 _indexOfBindingToEnable; // TYPE_INT32
        [FieldAttr(36)] public bool _hasOutputBinding; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(37)] public bool _initializedOffsets; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}