using Alchemy;

namespace Havok
{
    [ObjectAttr(64)]
    public class hknpMaterialLibrary : hkReferencedObject
    {
        public override uint Hash => 0x5c07fd6a;

        [FieldAttr(16)] public u32 _materialAddedSignal; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(24)] public u32 _materialModifiedSignal; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(32)] public u32 _materialRemovedSignal; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(40)] public hkFreeListArrayhknpMaterialhknpMaterialId8hknpMaterialFreeListArrayOperations _entries; // TYPE_STRUCT, ctype: hkFreeListArrayhknpMaterialhknpMaterialId8hknpMaterialFreeListArrayOperations
    }
}