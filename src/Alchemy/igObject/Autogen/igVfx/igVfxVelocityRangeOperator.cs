namespace Alchemy
{
    [ObjectAttr(72, 4)]
    public class igVfxVelocityRangeOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(40)] public igRangedFloatMetaField _x = new();
        [FieldAttr(48)] public igRangedFloatMetaField _y = new();
        [FieldAttr(56)] public igRangedFloatMetaField _z = new();
        [FieldAttr(64)] public EigVfxCurveCorrelation _correlation;
    }
}
