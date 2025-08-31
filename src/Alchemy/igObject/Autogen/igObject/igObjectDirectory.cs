namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class igObjectDirectory : igObject
    {
        public enum EFileType : uint
        {
            kAuto = 0,
            kIGB = 1,
            kIGX = 2,
            kDataStream = 3,
            kIGZ = 4,
        }

        [FieldAttr(16)] public igNameMetaField _name = new();
        [FieldAttr(32)] public string? _path = null;
        [FieldAttr(40)] public igObjectList? _objectList;
        [FieldAttr(48)] public bool _useNameList = true;
        [FieldAttr(56)] public igNameList? _nameList;
        [FieldAttr(64)] public bool _useNamespaceList;
        [FieldAttr(72)] public igNameList? _namespaceList;
        [FieldAttr(80)] public igMemoryList? _memory;
        [FieldAttr(88)] public igSizeTypeMetaField _memoryUsage = new();
        [FieldAttr(96)] public igSizeTypeMetaField _childMemoryUsage = new();
        [FieldAttr(104)] public igObject? _loaderData;
        [FieldAttr(112)] public igObjectLoader? _loader;
        [FieldAttr(120)] public EFileType _sourceFileType;
        [FieldAttr(124)] public int _loadCount;
        [FieldAttr(128)] public bool _allowMultipleInstances = true;
        [FieldAttr(136)] public igObjectList? _debugObjects;
        [FieldAttr(144)] public igVectorMetaField<igObjectDirectory> _dependencies = new();
        [FieldAttr(168)] public igThumbnailSet? _thumbnails;
        [FieldAttr(176)] public igBaseMetaList? _createdMetas;
    }
}
