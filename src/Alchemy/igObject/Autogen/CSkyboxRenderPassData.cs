namespace Alchemy
{
    [ObjectAttr(320, 16)]
    public class CSkyboxRenderPassData : igObject
    {
        [FieldAttr(16)] public igVfxRangedCurveMetaField _skyGradientColorRed = new();
        [FieldAttr(100)] public igVfxRangedCurveMetaField _skyGradientColorGreen = new();
        [FieldAttr(184)] public igVfxRangedCurveMetaField _skyGradientColorBlue = new();
        [FieldAttr(268)] public float _skyIntensity = 1.0f;
        [FieldAttr(272)] public float _sunIntensity = 10.0f;
        [FieldAttr(276)] public float _sunSize = 0.15f;
        [FieldAttr(288)] public igVec4fMetaField _sunshaftColor = new();
        [FieldAttr(304)] public float _sunshaftDecay = 0.98f;
        [FieldAttr(308)] public float _sunshaftDensity = 1.0f;
        [FieldAttr(312)] public float _sunshaftIntensity = 1.0f;
    }
}
