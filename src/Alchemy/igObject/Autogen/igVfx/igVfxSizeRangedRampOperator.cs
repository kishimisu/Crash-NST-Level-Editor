namespace Alchemy
{
    [ObjectAttr(88, 4)]
    public class igVfxSizeRangedRampOperator : igVfxSizeBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedRampMetaField _sizeX = new();
        [FieldAttr(48)] public igVfxRangedRampMetaField _sizeY = new();
        [FieldAttr(64)] public igVfxRangedRampMetaField _sizeZ = new();
        [FieldAttr(80)] public EigVfxCurveCorrelation _sizeCorrelation = EigVfxCurveCorrelation.kAspectRatio;
    }
}
