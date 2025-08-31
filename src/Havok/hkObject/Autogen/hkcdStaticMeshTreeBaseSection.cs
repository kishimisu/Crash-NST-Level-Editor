using Alchemy;

namespace Havok
{
    [ObjectAttr(96)]
    public class hkcdStaticMeshTreeBaseSection : hkcdStaticTreeTreehkcdStaticTreeDynamicStorage4
    {
        public override uint Hash => 0xfd01ccd8;

        [FieldAttr(48)] public float _codecParms_0; // TYPE_REAL, arrsize: 6
        [FieldAttr(52)] public float _codecParms_1;
        [FieldAttr(56)] public float _codecParms_2;
        [FieldAttr(60)] public float _codecParms_3;
        [FieldAttr(64)] public float _codecParms_4;
        [FieldAttr(68)] public float _codecParms_5;
        [FieldAttr(72)] public u32 _firstPackedVertex; // TYPE_UINT32
        [FieldAttr(76)] public u32 _sharedVertices; // TYPE_UINT32, (Inlined from type: hkcdStaticMeshTreeBaseSectionSharedVertices)
        [FieldAttr(80)] public u32 _primitives; // TYPE_UINT32, (Inlined from type: hkcdStaticMeshTreeBaseSectionPrimitives)
        [FieldAttr(84)] public u32 _dataRuns; // TYPE_UINT32, (Inlined from type: hkcdStaticMeshTreeBaseSectionDataRuns)
        [FieldAttr(88)] public u8 _numPackedVertices; // TYPE_UINT8
        [FieldAttr(89)] public u8 _numSharedIndices; // TYPE_UINT8
        [FieldAttr(90)] public u16 _leafIndex; // TYPE_UINT16
        [FieldAttr(92)] public u8 _page; // TYPE_UINT8
        [FieldAttr(93)] public u8 _flags; // TYPE_UINT8
        [FieldAttr(94)] public u8 _layerData; // TYPE_UINT8
        [FieldAttr(95)] public u8 _unusedData; // TYPE_UINT8
    }
}