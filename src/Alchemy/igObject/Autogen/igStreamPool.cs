namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igStreamPool : igPool
    {
        [FieldAttr(80)] public igRawRefMetaField _resetCallback = new();
    }
}
