namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 112, align: 8)]
    public class igVfxColorValueCurveOperator : igVfxColorValueBaseOperator
    {
        [FieldAttr(nst: 40, ctr: 24)] public igVfxRangedCurveMetaField _amount = new();
        [FieldAttr(nst: 124, ctr: 108)] public EOperatorCurveInput _inputParameter = EOperatorCurveInput.kTrackParameter1;
    }
}
