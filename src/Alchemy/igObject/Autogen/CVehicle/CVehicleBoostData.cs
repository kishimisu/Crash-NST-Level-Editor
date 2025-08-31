namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CVehicleBoostData : igObject
    {
        [FieldAttr(16)] public float _speed = 3000.0f;
        [FieldAttr(20)] public float _minimumSpeed;
        [FieldAttr(24)] public float _maximumSpeed = -1.0f;
        [FieldAttr(28)] public float _gravityMultiplier;
        [FieldAttr(32)] public float _boostDelayDuration;
        [FieldAttr(36)] public float _boostInDuration;
        [FieldAttr(40)] public float _boostSustainDuration = 1.0f;
        [FieldAttr(44)] public float _boostOutDuration;
        [FieldAttr(48)] public bool _allowJumping = true;
        [FieldAttr(56)] public igHandleMetaField _boostActivatedVfx = new();
        [FieldAttr(64)] public igHandleMetaField _vehicleBoostVfx = new();
        [FieldAttr(72)] public CBoltPoint? _vehicleVfxBoltPoint;
        [FieldAttr(80)] public igHandleMetaField _boostActivatedSfx = new();
        [FieldAttr(88)] public float _cameraFovModifier = 0.2f;
        [FieldAttr(92)] public bool _reorientToDirectionOfBoostEntity;
        [FieldAttr(96)] public float _reorientMagnitude = 1.0f;
        [FieldAttr(100)] public float _reorientdecayDelay = 0.5f;
        [FieldAttr(104)] public float _reorientdecayDuration = 0.5f;
    }
}
