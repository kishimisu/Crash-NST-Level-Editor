namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igPoolBucket : igObject
    {
        [FieldAttr(16)] public igMemoryRef<u8> _data = new();
        [FieldAttr(32)] public uint _count;
        [FieldAttr(40)] public igPoolBucket? _next;
    }
}
