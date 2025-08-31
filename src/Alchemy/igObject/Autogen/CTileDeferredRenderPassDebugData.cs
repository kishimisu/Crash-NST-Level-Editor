namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CTileDeferredRenderPassDebugData : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igSprite> _sprites = new();
        [FieldAttr(40)] public igVectorMetaField<igText> _texts = new();
    }
}
