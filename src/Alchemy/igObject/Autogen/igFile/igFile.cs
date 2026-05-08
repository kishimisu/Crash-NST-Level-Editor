namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class igFile : igObject
    {
        public enum EMode
        {
            kModeRead = 1,
            kModeWrite = 2,
            kModeReadWrite = 3,
            kModeText = 4,
            kModeReadText = 5,
            kModeWriteText = 6,
            kModeReadWriteText = 7,
            kModeCache = 8,
            kModeSequential = 16,
            kModeNoBuffer = 32,
            kModeCacheInternal = 64,
        }

        [FieldAttr(nst: 16, ctr: 16)] public igRawRefMetaField _file = new();
        [FieldAttr(nst: 24, ctr: 24)] public i64 _offset;
        [FieldAttr(nst: 32, ctr: 32)] public EPriority _priority;
    }
}
