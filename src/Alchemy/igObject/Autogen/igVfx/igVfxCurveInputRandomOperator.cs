namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxCurveInputRandomOperator : igVfxOperator
    {
        [FieldAttr(24)] public EOperatorCurveOutput _output = EOperatorCurveOutput.kSetTrackParameter1;
    }
}
