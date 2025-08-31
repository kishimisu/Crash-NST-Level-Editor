namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class igVfxSpawnedEffect : igObject
    {
        [ObjectAttr(4)]
        public class FlagStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public uint _cameraMask = 15;
            [FieldAttr(4, size: 3)] public int _priorityClass;
            [FieldAttr(7, size: 1)] public bool _isSoftKilled;
            [FieldAttr(8, size: 1)] public bool _isHardKilled;
            [FieldAttr(9, size: 1)] public bool _isPaused;
            [FieldAttr(10, size: 1)] public bool _isHardCulled;
            [FieldAttr(11, size: 1)] public bool _isIsolateCulled;
            [FieldAttr(12, size: 1)] public bool _isSoftCulled;
            [FieldAttr(13, size: 1)] public bool _primitivesSetup;
            [FieldAttr(14, size: 1)] public bool _lateUpdate;
            [FieldAttr(15, size: 1)] public bool _isPriorityPaused;
            [FieldAttr(16, size: 1)] public bool _isSubEffect;
            [FieldAttr(17, size: 1)] public bool _zeroTimeScale;
            [FieldAttr(18, size: 8)] public uint _loopCount;
        }

        [FieldAttr(16)] public igVfxEffect? _source;
        [FieldAttr(24)] public igTimeMetaField _age = new();
        [FieldAttr(28)] public float _totalWindupTime;
        [FieldAttr(32)] public float _elapsedWindupTime;
        [FieldAttr(36)] public float _hardCullPauseCountdown;
        [FieldAttr(40)] public float _timeScale = 1.0f;
        [FieldAttr(48)] public igVfxBolt? _bolt1;
        [FieldAttr(56)] public igVfxBolt? _bolt2;
        [FieldAttr(64)] public igVfxBolt? _groundBolt;
        [FieldAttr(72)] public igVfxBaseVariable? _variables;
        [FieldAttr(80)] public i8 _spawnGroupAtSpawn;
        [FieldAttr(81)] public u8 _spawnGroup;
        [FieldAttr(84)] public FlagStorage _flagStorage = new();
        [FieldAttr(88)] public u16 _spawnLayers;
        [FieldAttr(90)] public u16 _layer = 65535;
        [FieldAttr(92)] public float _priority;
        [FieldAttr(96)] public int _priorityFailureMask;
        [FieldAttr(100)] public float _maxBudgetFraction;
        [FieldAttr(104, false)] public igVfxPrimitive? _dependency;
        [FieldAttr(112)] public uint _seed;
        [FieldAttr(120, false)] public igVfxPrimitive? _headPrimitive;
    }
}
