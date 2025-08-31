namespace Alchemy
{
    [ObjectAttr(2704, 16)]
    public class igVfxManager : igObject
    {
        public enum ESpawnGroup : int
        {
            kSpawnGroupInherit = -1,
            kSpawnGroupDefault = 0,
            // kSpawnGroup0 = 0,
            kSpawnGroup1 = 1,
            kSpawnGroup2 = 2,
            kSpawnGroup3 = 3,
            kSpawnGroup4 = 4,
            kSpawnGroup5 = 5,
            kSpawnGroup6 = 6,
            kSpawnGroup7 = 7,
            kMaxSpawnGroupCount = 8,
        }

        public enum EffectKillType : uint
        {
            kSoftKill = 0,
            kHardKill = 1,
        }

        public enum EUpdatePhase : uint
        {
            kPostUpdate = 0,
            kEarlyPreUpdate = 1,
            kLatePreUpdate = 2,
        }

        public enum EDebugVisualizationLevel : uint
        {
            kNone = 0,
            kPrimitive = 1,
            kEffect = 2,
            kAll = 3,
        }

        public enum EVfxCamera : uint
        {
            kVfxCamera0 = 0,
            kVfxCamera1 = 1,
            kVfxCameraGUI = 2,
            kVfxCameraCount = 3,
        }

        [FieldAttr(16)] public igRawRefMetaField _stackUpdateFunction = new();
        [FieldAttr(24)] public bool _metricSystemUnits;
        [FieldAttr(25)] public bool _activated;
        [FieldAttr(26)] public bool _skipCulling;
        [FieldAttr(27)] public bool _doSkipCulling;
        [FieldAttr(28)] public bool _highQualityTrails;
        [FieldAttr(32)] public igMetaObjectPrimitiveInfoHashTable? _primitiveInfoTable;
        [FieldAttr(40)] public igMetaObjectVfxRuntimeObjectInfoHashTable? _spawnRateInfoTable;
        [FieldAttr(48)] public igMetaObjectVfxRuntimeObjectInfoHashTable? _spawnLocationInfoTable;
        [FieldAttr(56)] public igMetaObjectVfxRuntimeObjectInfoHashTable? _boltInfoTable;
        [FieldAttr(64)] public igMetaObjectVfxRuntimeObjectInfoHashTable? _dataBlockInfoTable;
        [FieldAttr(72)] public igVfxNonRefCountedPrimitiveInfoList? _primitiveInfoList;
        [FieldAttr(80, false)] public igVfxPrimitiveInfo? _primitiveInfo;
        [FieldAttr(88)] public igObject[] _operatorStorageInfo = new igObject[3];
        [FieldAttr(112)] public igVfxBolt? _sharedIntervalBolt;
        [FieldAttr(120)] public igObjectPool? _spawnedEffectPool;
        [FieldAttr(128)] public igObject[] _effects = new igObject[2];
        [FieldAttr(144)] public igObject[] _effectsByPriority = new igObject[2];
        [FieldAttr(160)] public bool[] _priorityRebalance = new bool[2];
        [FieldAttr(162)] public bool _queuedForSpawnDirty;
        [FieldAttr(168)] public igVfxSpawnedEffectHandleList? _queuedForSpawn;
        [FieldAttr(176)] public igObject[] _windupEffects = new igObject[2];
        [FieldAttr(192)] public float _parentWindupTime;
        [FieldAttr(196)] public igRandomMetaField _rng = new();
        [FieldAttr(204)] public float _frameDelta;
        [FieldAttr(208)] public igTimer? _spawnTimer;
        [FieldAttr(216)] public igVec3fMetaField _wind = new();
        [FieldAttr(232)] public igVectorMetaField<igVfxSpawnGroupPassInfo> _spawnGroupPassInfoList = new();
        [FieldAttr(256)] public igVectorMetaField<igNonRefCountedMetaObjectSpawnGroupPassDataHashTable> _spawnGroupPassInfoTableList = new();
        [FieldAttr(280)] public igVectorMetaField<igProcGeometryBuilder> _pgbs = new();
        [FieldAttr(304)] public igVectorMetaField<uint> _pgbFlags = new();
        [FieldAttr(328)] public igVectorMetaField<int> _pgbVertSizes = new();
        [FieldAttr(352)] public igDynamicBuffer? _procGeometryBuffer;
        [FieldAttr(360)] public igProcGeometryHelperPool? _pghPool;
        [FieldAttr(368, false)] public igAtomicSortKeyValueLinearAllocator? _sortKeyAllocator;
        [FieldAttr(376)] public igAtomicSortKeyValueListMetaField _sortKeyList = new();
        [FieldAttr(400)] public igVfxDrawCallPool? _vfxDrawCallPool;
        [FieldAttr(408)] public igVfxDecalDrawCallPool? _vfxDecalDrawCallPool;
        [FieldAttr(416)] public igObjectPool? _decalMatrixConstantBundlePool;
        [FieldAttr(424)] public igModelInstancePool? _modelInstancePool;
        [FieldAttr(432)] public igObjectPool? _colorConstantBundlePool;
        [FieldAttr(440)] public igObjectPool? _timeTransformPool;
        [FieldAttr(448)] public igStreamPool? _streamPool;
        [FieldAttr(456)] public bool _ownedPoolsFixed;
        [FieldAttr(457)] public bool _outOfMemory;
        [FieldAttr(464)] public string? _outOfMemoryCallSite = null;
        [FieldAttr(472)] public bool _reportOutOfMemory;
        [FieldAttr(476)] public int _maxProcVertexCount = -1;
        [FieldAttr(480)] public uint _pghPoolSize = 32;
        [FieldAttr(484)] public uint _boundingBoxPoolSize = 32;
        [FieldAttr(488)] public uint _geoAndMaterialPoolSize = 32;
        [FieldAttr(492)] public uint _spawnedEffectPoolCapacity = 32;
        [FieldAttr(496)] public uint _emitterCapacity = 32;
        [FieldAttr(500)] public uint _instanceCapacity = 32;
        [FieldAttr(504)] public uint _decalPoolCount = 32;
        [FieldAttr(508)] public uint _modelPoolCount = 32;
        [FieldAttr(512)] public u8 _spawnGroupCount = 1;
        [FieldAttr(528)] public igVfxManagerCameraDataMetaField[] _cameraData = new igVfxManagerCameraDataMetaField[1];
        [FieldAttr(2304)] public uint _activeCameras = 1;
        [FieldAttr(2308)] public uint _viewChanged = 4294967295;
        [FieldAttr(2320)] public igVec3fAlignedMetaField _worldForward = new();
        [FieldAttr(2336)] public igVec3fAlignedMetaField _worldRight = new();
        [FieldAttr(2352)] public igVec3fAlignedMetaField _worldUp = new();
        [FieldAttr(2368)] public igMatrix44fMetaField _invWorldMatrix = new();
        [FieldAttr(2432)] public igVec3fAlignedMetaField _gravity = new();
        [FieldAttr(2448)] public igVertexFormat? _decalVertexFormat;
        [FieldAttr(2456)] public igSizeTypeMetaField _decalVertexFormatResource = new();
        [FieldAttr(2464)] public igSizeTypeMetaField _decalVertexBufferResource = new();
        [FieldAttr(2472)] public igSizeTypeMetaField _decalIndexBufferResource = new();
        [FieldAttr(2480)] public bool _effectCullingEnabled = true;
        [FieldAttr(2481)] public bool _useOverrideCullDistance;
        [FieldAttr(2484)] public float _overrideCullDistance = 3.0f;
        [FieldAttr(2488)] public float _maxProcGeometryRadius = 1000.0f;
        [FieldAttr(2492)] public int _debugMaxProcVertCount = -1;
        [FieldAttr(2496)] public bool _expandPghLists;
        [FieldAttr(2500)] public EUpdatePhase _updatePhase;
        [FieldAttr(2504)] public bool _killAllSpawnedEffectsQueued;
        [FieldAttr(2512, false)] public igThread? _owner;
        [FieldAttr(2520)] public bool _bypassJobQueue;
        [FieldAttr(2524)] public EDebugVisualizationLevel _debugVisualizationLevel;
        [FieldAttr(2528)] public bool _visibility = true;
        [FieldAttr(2536)] public igVfxDebugData? _debugData;
        [FieldAttr(2544)] public igHandleMetaField _selectedEffect = new();
        [FieldAttr(2552)] public igHandleMetaField _selectedPrimitive = new();
        [FieldAttr(2560)] public bool _magicMomentHack;
        [FieldAttr(2564)] public float[] _cameraCullDistance = new float[3];
        [FieldAttr(2576)] public bool _cullZeroTimeScaleEffects;
        [FieldAttr(2584, false)] public igVfxSpawnedEffect? _updatingEffect;
        [FieldAttr(2592, false)] public igVfxPrimitive? _updatingPrimitive;
        [FieldAttr(2600)] public bool _enablePriorities = true;
        [FieldAttr(2604)] public igStatHandleMetaField _statHandleDeprioritised = new();
        [FieldAttr(2608)] public igStatHandleMetaField _statHandlePaused = new();
        [FieldAttr(2612)] public igStatHandleMetaField _statHandleEmpty = new();
        [FieldAttr(2616)] public igStatHandleMetaField _statHandleActive = new();
        [FieldAttr(2620)] public uint _currentFrame;
        [FieldAttr(2624)] public igMemoryRef<u8> _streamHeapMemory = new();
        [FieldAttr(2640)] public igMemoryRef<u8> _streamHeapLevelData = new();
        [FieldAttr(2656)] public int _streamBlockSize = 128;
        [FieldAttr(2660)] public int _streamBlockCount = 512;
        [FieldAttr(2664)] public igRawRefMetaField _streamHeap = new();
        [FieldAttr(2672)] public u16 _deviceClass = 65535;
        [FieldAttr(2676)] public igStatHandleMetaField _jqUpdateStatHandle = new();
        [FieldAttr(2680)] public bool _skipFrame;
        [FieldAttr(2684)] public float _averageFinishProcGeoTime;
        [FieldAttr(2688)] public float _averageStreamResetTime;
        [FieldAttr(2692)] public float _averageFinishCommandTime;
    }
}
