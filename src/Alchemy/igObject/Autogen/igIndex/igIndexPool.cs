namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igIndexPool : igObject
    {
        [FieldAttr(16)] public igMemoryRef<uint> _data = new();
        [FieldAttr(32)] public uint _allocatedCount;
    }
}
