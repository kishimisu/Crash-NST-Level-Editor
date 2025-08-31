namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxCurveInputStepOperator : igVfxOperator
    {
        [FieldAttr(24)] public int _stepCount = 3;
        [FieldAttr(28)] public EOperatorCurveInput _input;
        [FieldAttr(32)] public EOperatorCurveOutput _output = EOperatorCurveOutput.kSetTrackParameter1;
    }
}
