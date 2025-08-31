namespace Alchemy
{
    [ObjectAttr(208, 8)]
    public class igVfxPrimitiveInfo : igVfxRuntimeObjectInfo
    {
        [FieldAttr(48)] public igMetaObject? _dataType;
        [FieldAttr(56)] public igMetaObject? _instancePoolType;
        [FieldAttr(64)] public igVfxPrimitiveInstancePool? _instancePool;
        [FieldAttr(72)] public uint _instancePoolSize = 32;
        [FieldAttr(76)] public uint _spawnGroupCount = 1;
        [FieldAttr(80)] public uint _windingFlips = 3;
        [FieldAttr(88)] public igVfxPrimitiveList? _primitiveList;
        [FieldAttr(96)] public igVfxPrimitiveList? _latePrimitiveList;
        [FieldAttr(104)] public igStreamList? _streamList;
        [FieldAttr(112)] public igProcGeometryHelperList? _pghList;
        [FieldAttr(120)] public igIntList? _pgbIndexList;
        [FieldAttr(128)] public igVectorMetaField<igRawRefMetaField> _drawCallDataVector = new();
        [FieldAttr(152)] public igFxMaterialHandleList? _materialList;
        [FieldAttr(160)] public igUnsignedCharList? _spawnGroupList;
        [FieldAttr(168)] public igUnsignedCharList? _cameraIndexList;
        [FieldAttr(176)] public igUnsignedShortList? _layerList;
        [FieldAttr(184)] public bool _useInPrioritySystem = true;
        [FieldAttr(185)] public bool _shouldClearSceneRoot;
        [FieldAttr(188)] public int _primitiveIndex;
        [FieldAttr(192)] public igStatHandleMetaField _instanceCountStat = new();
        [FieldAttr(196)] public igStatHandleMetaField _primitiveCountStat = new();
        [FieldAttr(200)] public igStatHandleMetaField _instanceBudgetStat = new();
        [FieldAttr(204)] public igStatHandleMetaField _primitiveBudgetStat = new();
    }
}
