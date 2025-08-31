namespace Alchemy
{
    [ObjectAttr(176, 8)]
    public class CPlayerSystemData : igObject
    {
        [FieldAttr(16)] public float _resistanceConstant = 100.0f;
        [FieldAttr(20)] public float _strengthConstant = 100.0f;
        [FieldAttr(24)] public float _speedConstantCoef = 2.0f;
        [FieldAttr(28)] public float _speedConstantOffset = 170.0f;
        [FieldAttr(32)] public float _stickSpeedLimit = 2.0f;
        [FieldAttr(40)] public CActorInputMap? _controllerInputMap;
        [FieldAttr(48)] public CActorInputMap? _virtualControllerInputMap;
        [FieldAttr(56)] public float _lowHealthThreshold = 20.0f;
        [FieldAttr(64)] public igHandleMetaField _lowHealthVfx = new();
        [FieldAttr(72)] public igHandleMetaField _lowHealthVfxBoltPoint = new();
        [FieldAttr(80)] public float _criticalHealthThreshold = 20.0f;
        [FieldAttr(88)] public igHandleMetaField _criticalHealthVfx = new();
        [FieldAttr(96)] public igHandleMetaField _coopTetherVfx = new();
        [FieldAttr(104)] public igHandleMetaField _coopTetherRespawnVfx = new();
        [FieldAttr(112)] public float _heightOfPlayerCollisionEnds = 25.0f;
        [FieldAttr(120)] public CButtonAliasMapping? _buttonAliasMapping;
        [FieldAttr(128)] public float _maxGroundSlopeCosine = 0.70710683f;
        [FieldAttr(132)] public float _maxCeilingSlopeCosine = 0.70710683f;
        [FieldAttr(136)] public float _landDistance = 4.0f;
        [FieldAttr(140)] public float _maxVelocityForFlattenedLanding = 8.0f;
        [FieldAttr(144)] public float _capsuleRadius = 24.0f;
        [FieldAttr(148)] public float _stuckFallingDistanceThreshold = 20.0f;
        [FieldAttr(152)] public float _stuckFallingTime = 3.0f;
        [FieldAttr(160)] public string? _defaultCharacterName = "TemplateLegacy";
        [FieldAttr(168)] public CCameraTargetComponentData? _defaultCameraTargetComponent;
    }
}
