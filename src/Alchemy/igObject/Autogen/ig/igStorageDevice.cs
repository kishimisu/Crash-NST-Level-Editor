namespace Alchemy
{
    [ObjectAttr(nst: 120, align: 8)]
    public class igStorageDevice : igFileWorkItemProcessor
    {
        [FieldAttr(nst: 80)] public string? _name = null;
        [FieldAttr(nst: 88)] public string? _path = null;
        [FieldAttr(nst: 96)] public uint _readMediaAlignment = 1;
        [FieldAttr(nst: 100)] public uint _writeMediaAlignment = 1;
        [FieldAttr(nst: 104)] public uint _memoryAlignment = 1;
        [FieldAttr(nst: 108)] public uint _randomAccessTransferSize = 1;
        [FieldAttr(nst: 112)] public uint _sequentialTransferSize = 1;
        [FieldAttr(nst: 116)] public bool _readOnly;
        [FieldAttr(nst: 117)] public bool _removableMedia;
    }
}
