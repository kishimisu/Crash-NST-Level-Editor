namespace Alchemy
{
    [ObjectAttr(240, 8)]
    public class igDirectory : igObjectList
    {
        [FieldAttr(40)] public bool _loadPendingState;
        [FieldAttr(41)] public bool _validState;
        [FieldAttr(42)] public bool _compatibleState;
        [FieldAttr(44)] public int _loadedRefCount;
        [FieldAttr(48)] public bool _concreteState;
        [FieldAttr(56)] public igReferenceResolverSet? _referenceResolverSet;
        [FieldAttr(64)] public igReferenceResolverSet? _globalReferenceResolverSet;
        [FieldAttr(72)] public string? _name = null;
        [FieldAttr(80)] public igDirectoryList? _externalDirectoryList;
        [FieldAttr(88)] public igInfoList? _infoList;
        [FieldAttr(96, false)] public igResource? _managingResource;
        [FieldAttr(104)] public igShortListList? _metaFieldPerObjectIndices;
        [FieldAttr(112)] public bool _sharingState = true;
        [FieldAttr(113)] public bool _trackUniqueEntries;
        [FieldAttr(120)] public igDirectory? _uniqueEntryList;
        [FieldAttr(128)] public igRawRefList? _refList;
        [FieldAttr(136)] public igIntList? _alignmentList;
        [FieldAttr(144)] public bool _autoWriteFilePreProcessState = true;
        [FieldAttr(145)] public bool _useMemoryPoolAssignmentsState = true;
        [FieldAttr(146)] public bool _forceWriteMemoryPoolInfoFromMetaState;
        [FieldAttr(152)] public igStringRefList? _stringTable;
        [FieldAttr(160)] public bool _stringRefCompatibilityMode;
        [FieldAttr(168)] public igReferenceResolverContext? _resolverContext;
        [FieldAttr(176)] public igObjectDirectory? _objectDirectory;
        [FieldAttr(184)] public igVectorMetaField<igObjectDirectory> _dependencies = new();
        [FieldAttr(208)] public igUnsignedIntStringHashTable? _handleNames;
        [FieldAttr(216)] public igVectorMetaField<uint> _memoryPoolIndices = new();
    }
}
