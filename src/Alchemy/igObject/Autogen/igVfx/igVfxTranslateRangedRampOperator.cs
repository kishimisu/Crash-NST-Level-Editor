namespace Alchemy
{
    [ObjectAttr(88, 4)]
    public class igVfxTranslateRangedRampOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVfxRangedRampMetaField _x = new();
        [FieldAttr(48)] public igVfxRangedRampMetaField _y = new();
        [FieldAttr(64)] public igVfxRangedRampMetaField _z = new();
        [FieldAttr(80)] public EigVfxCurveCorrelation _correlation;
    }
}
