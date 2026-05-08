namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 64, align: 16)]
    public class igVfxCurveInputByPlaneDistanceOperator : igVfxFrameOperator
    {
        [FieldAttr(nst: 32, ctr: 20)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
        [FieldAttr(nst: 48, ctr: 32)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(nst: 64, ctr: 48)] public float _minDistance;
        [FieldAttr(nst: 68, ctr: 52)] public float _maxDistance = 100.0f;
    }
}
