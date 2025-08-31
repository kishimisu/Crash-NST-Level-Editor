namespace Alchemy
{
    [ObjectAttr(272, 16)]
    public class igModelInstance : igNamedObject
    {
        public enum EViewportID : uint
        {
            kViewportID_0 = 0,
            kViewportID_1 = 1,
            kViewportID_Count = 2,
        }

        public enum EDistanceCullImportance : uint
        {
            kVeryLow = 0,
            kLow = 1,
            kMedium = 2,
            kHigh = 3,
            kImportanceCount = 4,
            // kCritical = 4,
        }

        public enum EViewportFlag : uint
        {
            kViewportFlagNone = 0,
            kViewportFlag0 = 1,
            kViewportFlag1 = 2,
            kViewportFlagAll = 3,
        }

        [ObjectAttr(4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 16)] public uint _flags = 11;
            [FieldAttr(16, size: 1)] public bool _allowFrustumCulling = false;
            [FieldAttr(17, size: 3)] public igModelInstance.EDistanceCullImportance _distanceCullImportance = igModelInstance.EDistanceCullImportance.kVeryLow;
        }

        [FieldAttr(24, false)] public igModelInstance? _parent;
        [FieldAttr(32)] public u8 _forceCullFlags;
        [FieldAttr(33)] public u8 _forceViewportDisableFlags;
        [FieldAttr(34)] public u8 _visibleDebug = 2;
        [FieldAttr(35)] public u8 _classIndex = 1;
        [FieldAttr(36)] public i16 _stencilRef = -1;
        [FieldAttr(48)] public igMatrix44fMetaField _transform = new();
        [FieldAttr(112)] public igVec4fMetaField _min = new();
        [FieldAttr(128)] public igVec4fMetaField _max = new();
        [FieldAttr(144)] public uint _parentTransformIndex;
        [FieldAttr(148)] public uint _parentBoneIndex = 4294967295;
        [FieldAttr(152)] public igTimeTransform2? _timeTransform;
        [FieldAttr(160)] public igRawRefMetaField _blendMatrices = new();
        [FieldAttr(168)] public uint _blendMatrixCount;
        [FieldAttr(176)] public igRawRefMetaField _boneMatrices = new();
        [FieldAttr(184)] public uint _boneMatrixCount;
        [FieldAttr(192)] public igModelData? _data;
        [FieldAttr(200)] public Bitfield _bitfield = new();
        [FieldAttr(204)] public uint _filterId;
        [FieldAttr(208)] public string? _class = "main";
        [FieldAttr(216)] public igModelMaterialRedirectTable? _materialRedirectTable;
        [FieldAttr(224)] public igShaderConstantBundleList? _shaderConstantBundles;
        [FieldAttr(232)] public int _dynamicConstantBundleCount;
        [FieldAttr(240)] public igSizeTypeMetaField _bakedVertexBufferResource = new();
        [FieldAttr(248)] public igSizeTypeMetaField _bakedVertexFormatResource = new();
        [FieldAttr(256)] public int _bakedVertexDataBaseOffset = -1;
    }
}
