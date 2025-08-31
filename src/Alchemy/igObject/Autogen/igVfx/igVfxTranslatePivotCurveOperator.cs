namespace Alchemy
{
    [ObjectAttr(288, 4)]
    public class igVfxTranslatePivotCurveOperator : igVfxOperator
    {
        [FieldAttr(24)] public igVfxRangedCurveMetaField _x = new();
        [FieldAttr(108)] public igVfxRangedCurveMetaField _y = new();
        [FieldAttr(192)] public igVfxRangedCurveMetaField _z = new();
        [FieldAttr(276)] public EOperatorCurveInput _pivotInput;
        [FieldAttr(280)] public EigVfxCurveCorrelation _correlation;
    }
}
