namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CWaterVehicleExpeditionComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public EXBUTTON _ascendButton = EXBUTTON.JUMP;
        [FieldAttr(28)] public bool _useStickForMoveForward = true;
        [FieldAttr(29)] public bool _useButtonForMoveForward;
        [FieldAttr(32)] public EXBUTTON _moveForwardButton = EXBUTTON.R2;
        [FieldAttr(36)] public float _maxAngle = 37.0f;
        [FieldAttr(40)] public float _yawTurnRate = 90.0f;
        [FieldAttr(44)] public float _stickThreshold = 0.3f;
        [FieldAttr(48)] public float _maxHorizontalMovement = 400.0f;
        [FieldAttr(52)] public float _horizontalAcceleration = 600.0f;
        [FieldAttr(56)] public float _horizontalDeacceleration = 300.0f;
        [FieldAttr(60)] public float _maxVerticalMovement = 400.0f;
        [FieldAttr(64)] public float _verticalAcceleration = 600.0f;
        [FieldAttr(72)] public CSliderData? _verticalSliderData;
        [FieldAttr(80)] public float _verticalDeacceleration = 300.0f;
        [FieldAttr(84)] public float _runThreshold = 5.0f;
        [FieldAttr(88)] public string? _enterBehaviorState = "Expedition_Enter";
        [FieldAttr(96)] public string? _enterBehaviorEvent = "Expedition_Enter";
        [FieldAttr(104)] public string? _idleBehaviorState = "Expedition_Idle";
        [FieldAttr(112)] public string? _idleBehaviorEvent = "Expedition_Idle";
        [FieldAttr(120)] public string? _riseBehaviorState = "Expedition_Rise";
        [FieldAttr(128)] public string? _riseBehaviorEvent = "Expedition_Rise";
        [FieldAttr(136)] public string? _diveBehaviorState = "Expedition_Dive";
        [FieldAttr(144)] public string? _diveBehaviorEvent = "Expedition_Dive";
        [FieldAttr(152)] public string? _runBehaviorState = "Expedition_Run";
        [FieldAttr(160)] public string? _runBehaviorEvent = "Expedition_Run";
        [FieldAttr(168)] public igRangedFloatMetaField _raycastRange = new();
        [FieldAttr(176)] public float _groundDistance = 40.0f;
        [FieldAttr(180)] public float _groundDistanceTolerance = 40.0f;
        [FieldAttr(184)] public float _groundToleranceSpringConstant = 0.01f;
        [FieldAttr(188)] public float _groundToleranceDampingConstant = 0.1f;
        [FieldAttr(192)] public bool _hoverWhileAttacking = true;
        [FieldAttr(196)] public float _hoverAttackDistanceTolerance = 10.0f;
        [FieldAttr(200)] public float _hoverAttackSpringConstant = 0.01f;
        [FieldAttr(204)] public float _hoverAttackDampingConstant = 0.1f;
        [FieldAttr(208)] public igHandleMetaField _jumpVfx = new();
    }
}
