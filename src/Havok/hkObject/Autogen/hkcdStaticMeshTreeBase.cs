using Alchemy;

namespace Havok
{
    [ObjectAttr(112)]
    public class hkcdStaticMeshTreeBase : hkcdStaticTreeTreehkcdStaticTreeDynamicStorage5
    {
        public override uint Hash => 0xf885dcd0;

        [FieldAttr(48)] public i32 _numPrimitiveKeys; // TYPE_INT32
        [FieldAttr(52)] public i32 _bitsPerKey; // TYPE_INT32
        [FieldAttr(56)] public u32 _maxKeyValue; // TYPE_UINT32
        [FieldAttr(64)] public hkMemory<hkcdStaticMeshTreeBaseSection> _sections; // TYPE_ARRAY, ctype: hkcdStaticMeshTreeBaseSection, subtype: TYPE_STRUCT
        [FieldAttr(80)] public hkMemory<hkcdStaticMeshTreeBasePrimitive> _primitives; // TYPE_ARRAY, ctype: hkcdStaticMeshTreeBasePrimitive, subtype: TYPE_STRUCT
        [FieldAttr(96)] public hkMemory<u16> _sharedVerticesIndex; // TYPE_ARRAY, subtype: TYPE_UINT16
    }
}