using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(192)]
    public class hknpCompoundShape : hknpCompositeShape
    {
        public override uint Hash => 0x247d5e99;

        [FieldAttr(96)] public hkMemory<hknpShapeInstance> _elements; // TYPE_ARRAY, ctype: hknpShapeInstance, subtype: TYPE_STRUCT, (Inlined from type: hkFreeListArrayhknpShapeInstancehkHandleshort32767hknpShapeInstanceIdDiscriminant8hknpShapeInstance)
        [FieldAttr(112)] public i32 _firstFree; // TYPE_INT32, (Inlined from type: hkFreeListArrayhknpShapeInstancehkHandleshort32767hknpShapeInstanceIdDiscriminant8hknpShapeInstance)
        [FieldAttr(128)] public Vector4 _min; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(144)] public Vector4 _max; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(160)] public bool _isMutable; // TYPE_BOOL
        [FieldAttr(168)] public u32 _shapeMutated; // TYPE_POINTER, flags: SERIALIZE_IGNORED, (Inlined from type: hknpShapeSignals)
        [FieldAttr(176)] public u32 _shapeDestroyed; // TYPE_POINTER, flags: SERIALIZE_IGNORED, (Inlined from type: hknpShapeSignals)
    }
}