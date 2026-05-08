namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 8)]
    public class igVfxCurveInputLifetimeScaleOperator : igVfxOperator
    {
        [FieldAttr(nst: 24, ctr: 16)] public igVfxRangedCurveMetaField _lifetimeScale = new();
        [FieldAttr(nst: 108, ctr: 100)] public EOperatorCurveInput _inputParameter = EOperatorCurveInput.kTrackParameter1;
    }
}
