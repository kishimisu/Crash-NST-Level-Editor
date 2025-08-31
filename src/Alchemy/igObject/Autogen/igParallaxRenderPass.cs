namespace Alchemy
{
    [ObjectAttr(480, 16)]
    public class igParallaxRenderPass : igSceneRenderPass
    {
        [FieldAttr(464)] public igHandleMetaField _params = new();
        [FieldAttr(472)] public string? _parallaxCameraName = null;
    }
}
