namespace Alchemy
{
    [ObjectAttr(288, 16)]
    public class igCascadeShadowParametersBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _shiftX = new();
        [FieldAttr(48)] public igVec4fMetaField _shiftY = new();
        [FieldAttr(64)] public igVec4fMetaField _shiftZ = new();
        [FieldAttr(80)] public igVec4fMetaField _scaleX = new();
        [FieldAttr(96)] public igVec4fMetaField _scaleY = new();
        [FieldAttr(112)] public igVec4fMetaField _scaleZ = new();
        [FieldAttr(128)] public igVec4fMetaField _blend = new();
        [FieldAttr(144)] public igMatrix44fMetaField _worldToLightMatrix = new();
        [FieldAttr(208)] public igMatrix44fMetaField _viewToLightMatrix = new();
        [FieldAttr(272)] public igVec4fMetaField _viewspaceLightDirection = new();
    }
}
