namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CTileDeferredRenderPassDrawCallPool : igPool
    {
        [FieldAttr(80)] public igRawRefMetaField _resetCallback = new();
    }
}
