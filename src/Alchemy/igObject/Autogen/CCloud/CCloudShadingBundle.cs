namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class CCloudShadingBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _cloudsLightVertical = 0.5f;
        [FieldAttr(28)] public float _cloudsLightWrap = 0.6f;
        [FieldAttr(32)] public igVec4fMetaField _cloudsLitColor = new();
        [FieldAttr(48)] public igVec4fMetaField _cloudsDarkColor = new();
        [FieldAttr(64)] public igVec4fMetaField _cloudsHighlightColor = new();
        [FieldAttr(80)] public igVec4fMetaField _cloudsHighlightParams = new();
        [FieldAttr(96)] public float _cloudsShadowStrength = 0.2f;
        [FieldAttr(112)] public igVec4fMetaField _cloudsShadowColor = new();
        [FieldAttr(128)] public igVec4fMetaField _cloudsShadowParams = new();
        [FieldAttr(144)] public float _cloudsHazeStrength = 1.0f;
    }
}
