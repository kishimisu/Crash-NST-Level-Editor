namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igSound : igObject
    {
        [FieldAttr(16)] public igRawRefMetaField _sound = new();
        [FieldAttr(24)] public igRawRefMetaField _channel = new();
    }
}
