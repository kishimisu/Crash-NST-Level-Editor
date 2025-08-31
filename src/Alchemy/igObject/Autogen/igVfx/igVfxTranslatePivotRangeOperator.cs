namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class igVfxTranslatePivotRangeOperator : igVfxOperator
    {
        [FieldAttr(24)] public igRangedFloatMetaField _x = new();
        [FieldAttr(32)] public igRangedFloatMetaField _y = new();
        [FieldAttr(40)] public igRangedFloatMetaField _z = new();
        [FieldAttr(48)] public EigVfxCurveCorrelation _correlation;
    }
}
