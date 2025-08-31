namespace Alchemy
{
    [ObjectAttr(128, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_CManualMoverHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _stickThreshold = 0.3f;
        [FieldAttr(84)] public float _movementSpeed = 750.0f;
        [FieldAttr(88)] public float _fallGravity = 500.0f;
        [FieldAttr(92)] public bool _setVelocityDirectly = true;
        [FieldAttr(93)] public bool _useActorDirection;
        [FieldAttr(94)] public bool _resetVelocityEachFrame = true;
        [FieldAttr(95)] public bool _enableDeceleration;
        [FieldAttr(96)] public bool _onlyDecelerateWhileMoving = true;
        [FieldAttr(100)] public float _decelerationMinSpeed;
        [FieldAttr(104)] public float _decelerationRate = 300.0f;
        [FieldAttr(108)] public float _decelerationDelay;
        [FieldAttr(112)] public float _maxDuration;
        [FieldAttr(120)] public string? _cancelEvent = null;
    }
}
