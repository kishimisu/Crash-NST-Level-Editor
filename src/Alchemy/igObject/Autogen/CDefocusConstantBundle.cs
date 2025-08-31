namespace Alchemy
{
    [ObjectAttr(128, 16)]
    public class CDefocusConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _focusPlanes = new();
        [FieldAttr(48)] public igVec4fMetaField _focusPlanesDx11 = new();
        [FieldAttr(64)] public igVec4fMetaField _focusParameters = new();
        [FieldAttr(80)] public bool _nearFieldDefocus;
        [FieldAttr(84)] public float _nearNormalize = 1.0f;
        [FieldAttr(88)] public float _farNormalize = 1.0f;
        [FieldAttr(92)] public int _maxCoCRadiusPixels = 5;
        [FieldAttr(96)] public int _nearBlurRadiusPixels = 5;
        [FieldAttr(100)] public float _invNearBlurRadiusPixels = 0.2f;
        [FieldAttr(104)] public float _fade;
        [FieldAttr(108)] public float _nearBlurRadiusFraction = 0.005f;
        [FieldAttr(112)] public float _farBlurRadiusFraction = 0.005f;
    }
}
