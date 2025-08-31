namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class igVfxSpinAxisRateCurveOperator : igVfxSpinAxisRateBaseOperator
    {
        [FieldAttr(64)] public igVfxRangedCurveMetaField _rate = new();
        [FieldAttr(148)] public EOperatorCurveInput _rateInput;
    }
}
