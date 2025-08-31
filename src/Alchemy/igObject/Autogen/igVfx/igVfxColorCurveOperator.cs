namespace Alchemy
{
    [ObjectAttr(400, 16)]
    public class igVfxColorCurveOperator : igVfxColorBaseOperator
    {
        [FieldAttr(32)] public igVfxRgbCurveMetaField _colorCurve = new();
        [FieldAttr(304)] public igVfxRangedCurveMetaField _alpha = new();
        [FieldAttr(388)] public EOperatorCurveInput _colorInput;
    }
}
