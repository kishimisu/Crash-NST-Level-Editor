namespace Alchemy
{
    [ObjectAttr(496, 16)]
    public class CComposeSceneRenderPass : igSceneRenderPass
    {
        [FieldAttr(464)] public float _viewportRelativeX;
        [FieldAttr(468)] public float _viewportRelativeWidth = 1.0f;
        [FieldAttr(472)] public float _viewportRelativeY;
        [FieldAttr(476)] public float _viewportRelativeHeight = 1.0f;
        [FieldAttr(480)] public igSizeTypeMetaField _textureMatrixResource = new();
    }
}
