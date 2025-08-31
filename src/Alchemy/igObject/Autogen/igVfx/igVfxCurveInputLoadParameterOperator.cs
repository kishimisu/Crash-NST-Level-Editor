namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxCurveInputLoadParameterOperator : igVfxOperator
    {
        [FieldAttr(24)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
        [FieldAttr(28)] public int _index = 1;
    }
}
