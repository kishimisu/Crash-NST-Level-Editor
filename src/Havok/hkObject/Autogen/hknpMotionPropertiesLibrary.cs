using Alchemy;

namespace Havok
{
    [ObjectAttr(64)]
    public class hknpMotionPropertiesLibrary : hkReferencedObject
    {
        public override uint Hash => 0xc131fa71;

        [FieldAttr(16)] public u32 _entryAddedSignal; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(24)] public u32 _entryModifiedSignal; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(32)] public u32 _entryRemovedSignal; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(40)] public hkFreeListArrayhknpMotionPropertieshknpMotionPropertiesId8hknpMotionPropertiesFreeListArrayOperations _entries; // TYPE_STRUCT, ctype: hkFreeListArrayhknpMotionPropertieshknpMotionPropertiesId8hknpMotionPropertiesFreeListArrayOperations
    }
}