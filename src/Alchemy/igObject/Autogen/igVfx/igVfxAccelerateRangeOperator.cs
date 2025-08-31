namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class igVfxAccelerateRangeOperator : igVfxAccelerateBaseOperator
    {
        [FieldAttr(32)] public igRangedFloatMetaField _x = new();
        [FieldAttr(40)] public igRangedFloatMetaField _y = new();
        [FieldAttr(48)] public igRangedFloatMetaField _z = new();
        [FieldAttr(56)] public EigVfxCurveCorrelation _correlation;
    }
}
