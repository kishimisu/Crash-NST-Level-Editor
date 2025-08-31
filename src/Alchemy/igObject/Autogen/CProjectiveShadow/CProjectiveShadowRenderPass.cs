namespace Alchemy
{
    [ObjectAttr(528, 16)]
    public class CProjectiveShadowRenderPass : igSceneRenderPass
    {
        [FieldAttr(464)] public igHandleMetaField _light = new();
        [FieldAttr(472)] public igHandleMetaField _params = new();
        [FieldAttr(480)] public string? _shadowCameraName = null;
        [FieldAttr(488)] public string? _sceneCameraName_1 = null;
        [FieldAttr(496)] public CProjectiveShadowParametersBundle? _shadowParameters;
        [FieldAttr(504)] public igRenderCamera? _shadowCamera;
        [FieldAttr(512)] public int _outputSize = 1024;
    }
}
