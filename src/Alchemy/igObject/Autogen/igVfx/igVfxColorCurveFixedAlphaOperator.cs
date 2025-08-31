namespace Alchemy
{
    [ObjectAttr(320, 16)]
    public class igVfxColorCurveFixedAlphaOperator : igVfxColorBaseOperator
    {
        [FieldAttr(32)] public igVfxRgbCurveMetaField _colorCurve = new();
        [FieldAttr(304)] public float _alpha = 1.0f;
        [FieldAttr(308)] public EOperatorCurveInput _colorInput;
    }
}
