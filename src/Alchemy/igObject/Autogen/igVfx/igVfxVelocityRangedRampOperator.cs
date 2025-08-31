namespace Alchemy
{
    [ObjectAttr(96, 4)]
    public class igVfxVelocityRangedRampOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(40)] public igVfxRangedRampMetaField _x = new();
        [FieldAttr(56)] public igVfxRangedRampMetaField _y = new();
        [FieldAttr(72)] public igVfxRangedRampMetaField _z = new();
        [FieldAttr(88)] public EigVfxCurveCorrelation _correlation;
    }
}
