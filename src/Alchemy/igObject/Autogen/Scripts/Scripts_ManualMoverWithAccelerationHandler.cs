namespace Alchemy
{
    [ObjectAttr(112, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_ManualMoverWithAccelerationHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _speedXY = 750.0f;
        [FieldAttr(84)] public float _speedXYBoost = 1000.0f;
        [FieldAttr(88)] public float _accelerationXY = 1000.0f;
        [FieldAttr(92)] public float _decelerationXY = 1000.0f;
        [FieldAttr(96)] public bool _zeroVelocityOnExit = true;
        [FieldAttr(97)] public bool _useAccelerationWhenChangingDirection = true;
        [FieldAttr(98)] public bool _useActorDirectionNotStick;
        [FieldAttr(99)] public bool _accelerationDisabled;
        [FieldAttr(100)] public float _twistSpeed = 90.0f;
        [FieldAttr(104)] public float _twistThreshold = 20.0f;
    }
}
