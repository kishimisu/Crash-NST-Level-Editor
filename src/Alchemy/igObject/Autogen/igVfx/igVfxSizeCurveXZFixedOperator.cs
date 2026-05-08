namespace Alchemy
{
    [ObjectAttr(nst: 136, ctr: 120, align: 8)]
    public class igVfxSizeCurveXZFixedOperator : igVfxSizeBaseOperator
    {
        [FieldAttr(nst: 32, ctr: 20)] public float _sizeX = 1.0f;
        [FieldAttr(nst: 36, ctr: 24)] public igVfxRangedCurveMetaField _sizeY = new();
        [FieldAttr(nst: 120, ctr: 108)] public float _sizeZ = 1.0f;
        [FieldAttr(nst: 124, ctr: 112)] public EOperatorCurveInput _sizeInput;
        [FieldAttr(nst: 128, ctr: 116)] public EigVfxCurveCorrelation _sizeCorrelation = EigVfxCurveCorrelation.kAspectRatio;
    }
}
