namespace Alchemy
{
    [ObjectAttr(296, 4)]
    public class igVfxRotateEulerCurveOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _x = new();
        [FieldAttr(116)] public igVfxRangedCurveMetaField _y = new();
        [FieldAttr(200)] public igVfxRangedCurveMetaField _z = new();
        [FieldAttr(284)] public EOperatorCurveInput _eulerInput;
        [FieldAttr(288)] public EigVfxCurveCorrelation _correlation;
    }
}
