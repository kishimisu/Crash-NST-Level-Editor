namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igResource : igObject
    {
        [FieldAttr(16)] public bool _useMemoryPoolAssignmentsState = true;
        [FieldAttr(24)] public igDirectoryList? _directoryList;
        [FieldAttr(32)] public string? _relativeFilePath = null;
        [FieldAttr(40)] public string? _absoluteFilePath = null;
        [FieldAttr(48)] public bool _autoCompatibility = true;
        [FieldAttr(49)] public bool _IGBSharingState = true;
        [FieldAttr(52)] public int _IGBChunkSize = 131072;
        [FieldAttr(56)] public igReferenceResolverSet? _referenceResolverSet;
    }
}
