namespace Alchemy
{
    [ObjectAttr(184, 8, metaType: typeof(CGroundLocomotionHandler))]
    public class CGroundLocomotionHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _transitionTimeToWalkState = 0.05f;
        [FieldAttr(84)] public float _transitionTimeToIdleState = 0.05f;
        [FieldAttr(88)] public float _runTimeForStop = 1.0f;
        [FieldAttr(96)] public string? _idleEventName = "Idle";
        [FieldAttr(104)] public string? _walkEventName = "Walk";
        [FieldAttr(112)] public string? _runEventName = "Run";
        [FieldAttr(120)] public string? _runStopEventName = "Run_Stop";
        [FieldAttr(128)] public string? _idleStateName = "Idle";
        [FieldAttr(136)] public string? _walkStateName = "Walk";
        [FieldAttr(144)] public string? _runStateName = "Run";
        [FieldAttr(152)] public string? _runStopStateName = "Run_Stop";
        [FieldAttr(160)] public string? _landStateName = "Land";
        [FieldAttr(168)] public string? _landRunningStateName = "Land_Running";
        [FieldAttr(176)] public string? _runToIdleStateName = "Run to Idle";
    }
}
