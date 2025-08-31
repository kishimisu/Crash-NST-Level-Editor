namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class CSceneViewInverseBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igMatrix44fMetaField _inverseViewMatrix = new();
        [FieldAttr(96)] public igMatrix44fMetaField _viewMatrix = new();
    }
}
