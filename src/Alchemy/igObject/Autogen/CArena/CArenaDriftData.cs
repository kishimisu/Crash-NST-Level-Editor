namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class CArenaDriftData : CDriftData
    {
        [FieldAttr(72)] public bool _canDriftInAir;
        [FieldAttr(76)] public float _speedRequiredForArenaDrifting = 1000.0f;
        [FieldAttr(80)] public float _timeOfNoStickInputToEnd = 0.25f;
        [FieldAttr(84)] public int _numberOfSpinOutsToCancelDrift = 4;
        [FieldAttr(88)] public CBoltPoint? _pivot;
        [FieldAttr(96)] public float _timeToMaxPivot = 0.1f;
        [FieldAttr(100)] public float _spinOutForwardAngleStartThreshold = 75.0f;
        [FieldAttr(104)] public float _spinOutAccelerationAngleStartThreshold = 75.0f;
        [FieldAttr(108)] public float _spinOutForwardAngleStopThreshold = 10.0f;
        [FieldAttr(112)] public float _spinOutAccelerationAngleStopThreshold = 30.0f;
        [FieldAttr(116)] public float _minForwardSpeed = 1000.0f;
        [FieldAttr(120)] public float _maxForceForwardSpeed = 200.0f;
        [FieldAttr(124)] public float _driftDurationForBoostLevel2 = 0.5f;
        [FieldAttr(128)] public float _driftDurationForBoostLevel3 = 3.0f;
    }
}
