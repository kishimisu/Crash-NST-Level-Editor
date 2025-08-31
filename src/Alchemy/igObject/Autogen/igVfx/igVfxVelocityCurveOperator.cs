namespace Alchemy
{
    [ObjectAttr(304, 4)]
    public class igVfxVelocityCurveOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(40)] public igVfxRangedCurveMetaField _x = new();
        [FieldAttr(124)] public igVfxRangedCurveMetaField _y = new();
        [FieldAttr(208)] public igVfxRangedCurveMetaField _z = new();
        [FieldAttr(292)] public EOperatorCurveInput _velocityInput;
        [FieldAttr(296)] public EigVfxCurveCorrelation _correlation;
    }
}
