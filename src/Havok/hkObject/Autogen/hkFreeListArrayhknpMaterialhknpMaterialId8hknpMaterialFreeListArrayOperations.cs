using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkFreeListArrayhknpMaterialhknpMaterialId8hknpMaterialFreeListArrayOperations : hkObject
    {
        public override uint Hash => 0x7a67e9de;

        [FieldAttr(0)] public hkMemory<hknpMaterial> _elements; // TYPE_ARRAY, ctype: hknpMaterial, subtype: TYPE_STRUCT
        [FieldAttr(16)] public i32 _firstFree; // TYPE_INT32
    }
}