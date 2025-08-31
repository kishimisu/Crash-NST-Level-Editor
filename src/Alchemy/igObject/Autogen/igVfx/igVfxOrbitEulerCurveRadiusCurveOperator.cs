namespace Alchemy
{
    [ObjectAttr(392, 4)]
    public class igVfxOrbitEulerCurveRadiusCurveOperator : igVfxOrbitBaseOperator
    {
        [FieldAttr(40)] public igVfxRangedCurveMetaField _x = new();
        [FieldAttr(124)] public igVfxRangedCurveMetaField _y = new();
        [FieldAttr(208)] public igVfxRangedCurveMetaField _z = new();
        [FieldAttr(292)] public EOperatorCurveInput _eulerInput;
        [FieldAttr(296)] public EigVfxCurveCorrelation _correlation;
        [FieldAttr(300)] public igVfxRangedCurveMetaField _radius = new();
        [FieldAttr(384)] public EOperatorCurveInput _radiusInput;
    }
}
