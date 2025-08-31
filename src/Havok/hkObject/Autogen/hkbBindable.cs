using Alchemy;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkbBindable : hkReferencedObject
    {
        public override uint Hash => 0x654ce763;

        [FieldAttr(16)] public hkbVariableBindingSet _variableBindingSet; // TYPE_POINTER, ctype: hkbVariableBindingSet, subtype: TYPE_STRUCT
        [FieldAttr(24)] public hkMemory<u32> _cachedBindables; // TYPE_ARRAY, subtype: TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(40)] public bool _areBindablesCached; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(41)] public bool _hasEnableChanged; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}