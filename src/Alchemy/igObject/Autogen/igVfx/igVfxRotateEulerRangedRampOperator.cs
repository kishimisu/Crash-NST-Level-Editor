namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 72, align: 8)]
    public class igVfxRotateEulerRangedRampOperator : igVfxFrameOperator
    {
        [FieldAttr(nst: 32, ctr: 20)] public igVfxRangedRampMetaField _x = new();
        [FieldAttr(nst: 48, ctr: 36)] public igVfxRangedRampMetaField _y = new();
        [FieldAttr(nst: 64, ctr: 52)] public igVfxRangedRampMetaField _z = new();
        [FieldAttr(nst: 80, ctr: 68)] public EigVfxCurveCorrelation _correlation;
    }
}
