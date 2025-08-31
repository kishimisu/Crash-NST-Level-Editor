namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxAlphaCurveOperator : igVfxAlphaBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _alpha = new();
        [FieldAttr(116)] public EOperatorCurveInput _alphaInput;
    }
}
