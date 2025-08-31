namespace Alchemy
{
    [ObjectAttr(192, 16)]
    public class CColorAdjustmentBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _colorAdjustment = new();
        [FieldAttr(48)] public igVec4fMetaField _colorTint = new();
        [FieldAttr(64)] public igVec4fMetaField _hueAdjustment1 = new();
        [FieldAttr(80)] public igVec4fMetaField _hueAdjustment2 = new();
        [FieldAttr(96)] public igVec4fMetaField _saturationAdjustment1 = new();
        [FieldAttr(112)] public igVec4fMetaField _saturationAdjustment2 = new();
        [FieldAttr(128)] public igVec4fMetaField _tonemapParameters = new();
        [FieldAttr(144)] public igVec4fMetaField _vignetteParameters1 = new();
        [FieldAttr(160)] public igVec4fMetaField _vignetteParameters2 = new();
        [FieldAttr(176)] public igVec4fMetaField _mobileColorAdjustment = new();
    }
}
