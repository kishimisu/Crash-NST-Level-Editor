namespace Alchemy
{
    [ObjectAttr(128, 16)]
    public class CProjectiveShadowParametersBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igMatrix44fMetaField _worldToLightMatrix = new();
        [FieldAttr(96)] public igVec4fMetaField _edgeFade = new();
        [FieldAttr(112)] public float _intensity;
    }
}
