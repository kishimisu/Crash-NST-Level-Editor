namespace Alchemy
{
    [ObjectAttr(168, 8)]
    public class igMemoryPool : igObject
    {
        [FieldAttr(16)] public igMutex? _lock;
        [FieldAttr(24)] public bool _active;
        [FieldAttr(28)] public int _poolIndex = -1;
        [FieldAttr(32)] public igRawRefMetaField _address = new();
        [FieldAttr(40)] public igSizeTypeMetaField _size = new();
        [FieldAttr(48)] public uint _alignment;
        [FieldAttr(52)] public uint _userFlags;
        [FieldAttr(56)] public bool _lockOnOperation;
        [FieldAttr(57)] public bool _isThreadSafe;
        [FieldAttr(64, false)] public igThread? _owner;
        [FieldAttr(72)] public bool _reportThreadSafety = true;
        [FieldAttr(73)] public bool _alchemyMemory = true;
        [FieldAttr(74)] public bool _reportOnFailure = true;
        [FieldAttr(75)] public bool _useSentinels;
        [FieldAttr(76)] public bool _fillMemory;
        [FieldAttr(77)] public bool _checkIntegrity;
        [FieldAttr(80)] public igSizeTypeMetaField _blocksAllocated = new();
        [FieldAttr(88)] public igSizeTypeMetaField _peakBlocksAllocated = new();
        [FieldAttr(96)] public igSizeTypeMetaField _userAllocated = new();
        [FieldAttr(104)] public igSizeTypeMetaField _peakUserAllocated = new();
        [FieldAttr(112)] public igSizeTypeMetaField _totalAllocated = new();
        [FieldAttr(120)] public igSizeTypeMetaField _peakTotalAllocated = new();
        [FieldAttr(128)] public int _ordinal;
        [FieldAttr(136)] public string? _name = null;
        [FieldAttr(144, false)] public igMemoryPool? _parentPool;
        [FieldAttr(152)] public igSizeTypeMetaField _largestFreeBlockSizeMinimum = new();
        [FieldAttr(160)] public bool _initializedForTag;
    }
}
