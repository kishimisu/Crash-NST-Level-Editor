namespace Alchemy
{
    [ObjectAttr(136, 4)]
    public class igVfxSizeCurveYZFixedOperator : igVfxSizeBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _sizeX = new();
        [FieldAttr(116)] public float _sizeY = 1.0f;
        [FieldAttr(120)] public float _sizeZ = 1.0f;
        [FieldAttr(124)] public EOperatorCurveInput _sizeInput;
        [FieldAttr(128)] public EigVfxCurveCorrelation _sizeCorrelation = EigVfxCurveCorrelation.kAspectRatio;
    }
}
