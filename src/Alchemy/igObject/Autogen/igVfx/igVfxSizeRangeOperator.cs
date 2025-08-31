namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class igVfxSizeRangeOperator : igVfxSizeBaseOperator
    {
        [FieldAttr(32)] public igRangedFloatMetaField _sizeX = new();
        [FieldAttr(40)] public igRangedFloatMetaField _sizeY = new();
        [FieldAttr(48)] public igRangedFloatMetaField _sizeZ = new();
        [FieldAttr(56)] public EigVfxCurveCorrelation _sizeCorrelation = EigVfxCurveCorrelation.kAspectRatio;
    }
}
