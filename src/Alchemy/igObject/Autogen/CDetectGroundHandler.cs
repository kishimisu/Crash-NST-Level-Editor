namespace Alchemy
{
    [ObjectAttr(160, 8, metaType: typeof(CDetectGroundHandler))]
    public class CDetectGroundHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public bool _enableFallEvent = true;
        [FieldAttr(84)] public float _noGroundFallTime = 0.1f;
        [FieldAttr(88)] public float _noGroundFallTimeWhenAttacking;
        [FieldAttr(92)] public float _maxGroundDistance = 15.0f;
        [FieldAttr(96)] public float _minGroundDistance = -12.0f;
        [FieldAttr(100)] public float _enableJumpBufferingGroundDistance = 15.0f;
        [FieldAttr(104)] public float _traceDistance = 400.0f;
        [FieldAttr(108)] public float _fallInitialVelocity = 1400.0f;
        [FieldAttr(112)] public float _supportRadius = 16.0f;
        [FieldAttr(116)] public float _groundSlideSpeed = 300.0f;
        [FieldAttr(120)] public float _airSlideSpeed = 100.0f;
        [FieldAttr(128)] public string? _locomotionState = "Locomotion";
        [FieldAttr(136)] public string? _airLocomotionState = "AirLocomotion";
        [FieldAttr(144)] public string? _landState = "Land";
        [FieldAttr(152)] public float _ledgeDistance = 50.0f;
        [FieldAttr(156)] public float _blockerHeightThreshold = 25.0f;
    }
}
