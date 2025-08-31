using Alchemy;

namespace Havok
{
    [ObjectAttr(160)]
    public class hkcdStaticMeshTreehkcdStaticMeshTreeCommonConfigunsignedintunsignedlonglong1121hknpCompressedMeshShapeTreeDataRun : hkcdStaticMeshTreeBase
    {
        public override uint Hash => 0x1da85e02;

        [FieldAttr(112)] public hkMemory<u32> _packedVertices; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(128)] public hkMemory<u64> _sharedVertices; // TYPE_ARRAY, subtype: TYPE_UINT64
        [FieldAttr(144)] public hkMemory<hknpCompressedMeshShapeTreeDataRun> _primitiveDataRuns; // TYPE_ARRAY, ctype: hknpCompressedMeshShapeTreeDataRun, subtype: TYPE_STRUCT
    }
}