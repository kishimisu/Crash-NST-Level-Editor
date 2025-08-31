using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkFreeListArrayhknpMotionPropertieshknpMotionPropertiesId8hknpMotionPropertiesFreeListArrayOperations : hkObject
    {
        public override uint Hash => 0x9903f451;

        [FieldAttr(0)] public hkMemory<hknpMotionProperties> _elements; // TYPE_ARRAY, ctype: hknpMotionProperties, subtype: TYPE_STRUCT
        [FieldAttr(16)] public i32 _firstFree; // TYPE_INT32
    }
}