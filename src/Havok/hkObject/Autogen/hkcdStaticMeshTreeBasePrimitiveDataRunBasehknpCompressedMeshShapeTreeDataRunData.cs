using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkcdStaticMeshTreeBasePrimitiveDataRunBasehknpCompressedMeshShapeTreeDataRunData : hkObject
    {
        public override uint Hash => 0xad836282;

        [FieldAttr(0)] public hknpCompressedMeshShapeTreeDataRunData _value; // TYPE_STRUCT, ctype: hknpCompressedMeshShapeTreeDataRunData
        [FieldAttr(2)] public u8 _index; // TYPE_UINT8
        [FieldAttr(3)] public u8 _count; // TYPE_UINT8
    }
}