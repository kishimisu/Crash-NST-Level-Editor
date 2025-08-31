namespace Alchemy
{
    [ObjectAttr(176, 16)]
    public class CCameraConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _direction = new();
        [FieldAttr(48)] public igMatrix44fMetaField _cameraFacingMatrix = new();
        [FieldAttr(112)] public igMatrix44fMetaField _shadowCameraFacingMatrix = new();
    }
}
