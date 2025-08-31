namespace Alchemy
{
    [ObjectAttr(120, 8, metaType: typeof(CMotorcycleDetectGroundHandler))]
    public class CMotorcycleDetectGroundHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _noGroundFallTime = 0.1f;
        [FieldAttr(84)] public float _maxGroundDistance = 15.0f;
        [FieldAttr(88)] public float _minGroundDistance = -12.0f;
        [FieldAttr(92)] public float _traceDistance = 400.0f;
        [FieldAttr(96)] public float _fallGravity = -100.0f;
        [FieldAttr(104)] public CMotorcycleLandEntityMessage? _landedMessage;
        [FieldAttr(112)] public CMotorcycleLeftGroundEntityMessage? _leftGroundMessage;
    }
}
