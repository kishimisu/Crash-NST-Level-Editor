namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CVehicleRiderData : igObject
    {
        [FieldAttr(16)] public CBoltPoint? _boltPoint;
        [FieldAttr(24)] public CBoltPoint? _transformationBoltPoint;
        [FieldAttr(32)] public bool _hideRider;
        [FieldAttr(40)] public igHandleMetaField _teleportToDrivingVfx = new();
        [FieldAttr(48)] public string? _enterEvent = "DrivingVehicle_Enter";
        [FieldAttr(56)] public string? _secondaryEnterEvent = "";
        [FieldAttr(64)] public string? _exitEvent = "Locomotion";
        [FieldAttr(72)] public string? _secondaryExitEvent = "";
        [FieldAttr(80)] public string? _exitModEvent = "CharacterModFadeOut";
        [FieldAttr(88)] public string? _idleEvent = "Drive_Idle";
        [FieldAttr(96)] public string? _idleState = "Drive_Idle";
        [FieldAttr(104)] public string? _movingEvent = "Drive_Run";
        [FieldAttr(112)] public string? _movingState = "Drive_Run";
        [FieldAttr(120)] public float _movingSpeedThreshold = 300.0f;
        [FieldAttr(128)] public string? _impactEvent = "Drive_Impact";
        [FieldAttr(136)] public float _impactSpeedThreshold = 300.0f;
        [FieldAttr(140)] public float _impactCooldown = 2.0f;
    }
}
