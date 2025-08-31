namespace Alchemy
{
    [ObjectAttr(56, 16)]
    public class CGuiRenderTargetDisplay : igGuiAsset
    {
        [FieldAttr(32)] public igHandleMetaField _renderTarget = new();
        [FieldAttr(40)] public igSprite? _renderSprite;
        [FieldAttr(48)] public bool _flipUVs = true;
    }
}
