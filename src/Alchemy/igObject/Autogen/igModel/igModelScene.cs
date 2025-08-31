namespace Alchemy
{
    [ObjectAttr(416, 16)]
    public class igModelScene : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<InstanceDataMetaField> _instances = new();
        [FieldAttr(40)] public igVectorMetaField<u8> _passLists = new();
        [FieldAttr(64)] public bool _fullRefilter = true;
        [FieldAttr(72)] public igRawRefAtomicLinearAllocator? _deferredFilterList;
        [FieldAttr(80)] public igUnsignedIntIntHashTable? _passListLookup;
        [FieldAttr(88)] public igObjectIntHashTable? _instanceToDataTable;
        [FieldAttr(96)] public int _maxNumberWorkers;
        [FieldAttr(104)] public igVectorMetaField<igPtrMemoryPool> _drawCallPools = new();
        [FieldAttr(128)] public igRawRefMetaField _batchParams = new();
        [FieldAttr(136)] public igRawRefMetaField _batchSizes = new();
        [FieldAttr(144)] public igRawRefMetaField _batchEndIndices = new();
        [FieldAttr(152)] public igRawRefMetaField _heap = new();
        [FieldAttr(160)] public igModelDrawCall? _defaultModelDrawCall;
        [FieldAttr(168)] public igSkinnedModelDrawCall? _defaultSkinnedModelDrawCall;
        [FieldAttr(176)] public igVectorMetaField<igPtrMemoryPool>[] _bufferedDataPools = new igVectorMetaField<igPtrMemoryPool>[3];
        [FieldAttr(248)] public uint _bufferedWriteIndex;
        [FieldAttr(252)] public uint _frame;
        [FieldAttr(256)] public int _bufferedDataPoolChunkSize = 32768;
        [FieldAttr(264)] public igVectorMetaField<CameraMetaField> _cameras = new();
        [FieldAttr(288)] public igVectorMetaField<PassFilterMetaField> _passFilters = new();
        [FieldAttr(320)] public int _jobCounter;
        [FieldAttr(328, false)] public igAtomicSortKeyValueLinearAllocator? _result;
        [FieldAttr(336)] public igTimeMetaField _time = new();
        [FieldAttr(340)] public bool _threaded;
        [FieldAttr(344)] public int _viewportCount = 2;
        [FieldAttr(348)] public uint[] _viewportMasks = new uint[2];
        [FieldAttr(356)] public uint[] _distanceCullCameraMasks = new uint[2];
        [FieldAttr(364)] public uint _cameraEnableMask;
        [FieldAttr(368)] public igMutex? _instancesMutex;
        [FieldAttr(376)] public igStatHandleMetaField _traverseTimeStat = new();
        [FieldAttr(380)] public igStatHandleMetaField _drawCallMemoryUsedStat = new();
        [FieldAttr(384)] public igStatHandleMetaField _bufferedMemoryUsedStat = new();
        [FieldAttr(388)] public igStatHandleMetaField _filterTimeStat = new();
        [FieldAttr(392)] public igStatHandleMetaField _filterCountStat = new();
        [FieldAttr(396)] public igStatHandleMetaField _heapMemoryUsedState = new();
        [FieldAttr(400)] public igStatHandleMetaField _heapBlocksUsedState = new();
        [FieldAttr(408, false)] public igModelInstance? _isolateModel;
    }
}
