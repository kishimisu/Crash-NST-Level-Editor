namespace Alchemy
{
    [ObjectAttr(80, 4)]
    public class igVfxTranslatePivotRangedRampOperator : igVfxOperator
    {
        [FieldAttr(24)] public igVfxRangedRampMetaField _x = new();
        [FieldAttr(40)] public igVfxRangedRampMetaField _y = new();
        [FieldAttr(56)] public igVfxRangedRampMetaField _z = new();
        [FieldAttr(72)] public EigVfxCurveCorrelation _correlation;
    }
}
