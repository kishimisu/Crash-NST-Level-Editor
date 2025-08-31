namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxCurveInputRemapOperator : igVfxOperator
    {
        [FieldAttr(24)] public igVfxRangedCurveMetaField _mapping = new();
        [FieldAttr(108)] public EOperatorCurveInput _inputParameter = EOperatorCurveInput.kTrackParameter1;
        [FieldAttr(112)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
    }
}
