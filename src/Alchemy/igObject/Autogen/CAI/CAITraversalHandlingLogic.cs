namespace Alchemy
{
    [ObjectAttr(184, 8, metaType: typeof(CAITraversalHandlingLogic))]
    public class CAITraversalHandlingLogic : CBehaviorLogic
    {
        [FieldAttr(80)] public float _turnRate = 360.0f;
        [FieldAttr(84)] public float _turnRateStopped = 360.0f;
        [FieldAttr(88)] public float _minAnimatedTurnAngle = 10.0f;
        [FieldAttr(92)] public float _runStickThreshold = 0.4f;
        [FieldAttr(96)] public float _walkStickThreshold;
        [FieldAttr(100)] public float _turnStickThreshold;
        [FieldAttr(104)] public string? _runEvent = "Run";
        [FieldAttr(112)] public string? _walkEvent = "Walk";
        [FieldAttr(120)] public string? _idleEvent = "Idle";
        [FieldAttr(128)] public string? _turnInPlaceClockwiseEvent = "Turn_InPlaceCW";
        [FieldAttr(136)] public string? _turnInPlaceCounterClockwiseEvent = "Turn_InPlaceCCW";
        [FieldAttr(144)] public string? _runState = "Run";
        [FieldAttr(152)] public string? _walkState = "Walk";
        [FieldAttr(160)] public string? _idleState = "Idle";
        [FieldAttr(168)] public string? _turnInPlaceClockwiseState = "Turn_InPlaceCW";
        [FieldAttr(176)] public string? _turnInPlaceCounterClockwiseState = "Turn_InPlaceCCW";
    }
}
