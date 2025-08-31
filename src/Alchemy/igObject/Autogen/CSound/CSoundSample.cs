namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSoundSample : igObject
    {
        [FieldAttr(16)] public igMemoryRef<u8> _data = new();
    }
}
