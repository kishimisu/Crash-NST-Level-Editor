namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class igVfxCurveInputByDistanceOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
        [FieldAttr(36)] public float _minDistance;
        [FieldAttr(40)] public float _maxDistance = 100.0f;
    }
}
