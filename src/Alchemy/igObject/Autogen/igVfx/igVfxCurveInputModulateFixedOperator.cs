namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 32, align: 8)]
    public class igVfxCurveInputModulateFixedOperator : igVfxOperator
    {
        [FieldAttr(nst: 24, ctr: 16)] public EOperatorCurveInput _inputParameter = EOperatorCurveInput.kTrackParameter1;
        [FieldAttr(nst: 28, ctr: 20)] public EModulation _modulation = EModulation.kModulate;
        [FieldAttr(nst: 32, ctr: 24)] public float _modulationParameter = 1.0f;
        [FieldAttr(nst: 36, ctr: 28)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
    }
}
