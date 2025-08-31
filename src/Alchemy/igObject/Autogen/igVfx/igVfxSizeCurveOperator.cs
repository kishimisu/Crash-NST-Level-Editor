namespace Alchemy
{
    [ObjectAttr(296, 4)]
    public class igVfxSizeCurveOperator : igVfxSizeBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _sizeX = new();
        [FieldAttr(116)] public igVfxRangedCurveMetaField _sizeY = new();
        [FieldAttr(200)] public igVfxRangedCurveMetaField _sizeZ = new();
        [FieldAttr(284)] public EOperatorCurveInput _sizeInput;
        [FieldAttr(288)] public EigVfxCurveCorrelation _sizeCorrelation = EigVfxCurveCorrelation.kAspectRatio;
    }
}
