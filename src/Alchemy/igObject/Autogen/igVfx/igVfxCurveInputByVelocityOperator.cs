namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class igVfxCurveInputByVelocityOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
        [FieldAttr(36)] public float _minVelocity;
        [FieldAttr(40)] public float _maxVelocity = 100.0f;
    }
}
