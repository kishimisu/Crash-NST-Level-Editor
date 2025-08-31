using Alchemy;

namespace Havok
{
    [ObjectAttr(192)]
    public class hkxVertexAnimation : hkReferencedObject
    {
        public override uint Hash => 0x27678cb3;

        [FieldAttr(16)] public float _time; // TYPE_REAL
        [FieldAttr(24)] public hkxVertexBuffer _vertData; // TYPE_STRUCT, ctype: hkxVertexBuffer
        [FieldAttr(160)] public hkMemory<i32> _vertexIndexMap; // TYPE_ARRAY, subtype: TYPE_INT32
        [FieldAttr(176)] public hkMemory<hkxVertexAnimationUsageMap> _componentMap; // TYPE_ARRAY, ctype: hkxVertexAnimationUsageMap, subtype: TYPE_STRUCT
    }
}