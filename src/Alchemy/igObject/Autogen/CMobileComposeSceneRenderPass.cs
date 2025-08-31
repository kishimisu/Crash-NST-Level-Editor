namespace Alchemy
{
    [ObjectAttr(624, 16)]
    public class CMobileComposeSceneRenderPass : igFullScreenRenderPass
    {
        [FieldAttr(592)] public float _viewportRelativeX;
        [FieldAttr(596)] public float _viewportRelativeWidth = 1.0f;
        [FieldAttr(600)] public float _viewportRelativeY;
        [FieldAttr(604)] public float _viewportRelativeHeight = 1.0f;
        [FieldAttr(608)] public igSizeTypeMetaField _textureMatrixResource = new();
    }
}
