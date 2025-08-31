namespace Alchemy
{
    [ObjectAttr(1776, 8)]
    public class CBaseVehicleControllerComponentData : CEntityComponentData
    {
        public enum EVehicleSteeringMode : uint
        {
            eVSM_None = 0,
            eVSM_Absolute = 1,
            eVSM_Relative = 2,
            eVSM_Count = 3,
        }

        public enum EVehicleAccelerateMode : uint
        {
            eVAM_None = 0,
            eVAM_Button = 1,
            eVAM_Stick = 2,
            eVAM_Auto = 3,
            eVAM_Hybrid = 4,
            eVAM_DualSpeed = 5,
            eVAM_Count = 6,
        }

        [FieldAttr(24)] public igHandleMetaField _flightControlsInvertedPlayer1 = new();
        [FieldAttr(32)] public igHandleMetaField _flightControlsInvertedPlayer2 = new();
        [FieldAttr(40)] public igHandleMetaField _accelerationModeButtonOnlyPlayer1 = new();
        [FieldAttr(48)] public igHandleMetaField _accelerationModeButtonOnlyPlayer2 = new();
        [FieldAttr(56)] public igHandleMetaField _settings = new();
        [FieldAttr(64)] public igHandleMetaField _racingSettings = new();
        [FieldAttr(72)] public igHandleMetaField _airArenaSettings = new();
        [FieldAttr(80)] public bool _calculateCentralBoostValue;
        [FieldAttr(88)] public CVehicleRubberBanding? _rubberBandingSettings;
        [FieldAttr(96)] public float _maxDeltaSurfaceAngle = 60.0f;
        [FieldAttr(100)] public igVfxRangedCurveMetaField _surfaceAnglePowerFactor = new();
        [FieldAttr(184)] public float _defaultRagdollCollisionResponseTime = 4.0f;
        [FieldAttr(188)] public igVfxRangedCurveMetaField _surfaceLinearAccelerationVelocityCurve = new();
        [FieldAttr(272)] public igVfxRangedCurveMetaField _surfaceLinearCoastingVelocityCurve = new();
        [FieldAttr(356)] public igVfxRangedCurveMetaField _surfaceLinearBrakingVelocityCurve = new();
        [FieldAttr(440)] public igVfxRangedCurveMetaField _airLinearAccelerationVelocityCurve = new();
        [FieldAttr(524)] public igVfxRangedCurveMetaField _airLinearCoastingVelocityCurve = new();
        [FieldAttr(608)] public igVfxRangedCurveMetaField _airLinearBrakingVelocityCurve = new();
        [FieldAttr(692)] public float _airLinearBrakingTimeMultiplier = 1.0f;
        [FieldAttr(696)] public EXBUTTON _jumpButton = EXBUTTON.JUMP;
        [FieldAttr(700)] public EXBUTTON _brakeButton = EXBUTTON.B;
        [FieldAttr(704)] public EXBUTTON _secondaryBrakeButton = EXBUTTON.BRAKE;
        [FieldAttr(708)] public bool _canBrakeWhileBoosting;
        [FieldAttr(712)] public EXBUTTON _driftButton = EXBUTTON.L2;
        [FieldAttr(716)] public EXBUTTON _driftButtonSecondary = EXBUTTON.L2;
        [FieldAttr(720)] public CArenaDriftData? _arenaDriftData;
        [FieldAttr(728)] public CLinearDriftData? _linearDriftData;
        [FieldAttr(736)] public bool _allowReverse;
        [FieldAttr(740)] public float _maxForwardSpeedToEnablReverse = 50.0f;
        [FieldAttr(744)] public float _jumpStopAngleThreshold = 91.0f;
        [FieldAttr(748)] public float _sapFromVelocityDirectionThreshold = 20.0f;
        [FieldAttr(752)] public bool _alwaysUseVelocityDirectionInAir;
        [FieldAttr(756)] public float _maxEnterParkXYVelocity = 50.0f;
        [FieldAttr(760)] public float _minExitParkXYVelocity = 100.0f;
        [FieldAttr(764)] public float _maxParkForwardAngle = 60.0f;
        [FieldAttr(768)] public float _maxParkSideAngle = 60.0f;
        [FieldAttr(772)] public float _overTopSpeedCorrectionTime = 0.5f;
        [FieldAttr(776)] public igVfxRangedCurveMetaField _overTopSpeedCorrectionCurve = new();
        [FieldAttr(860)] public bool _allowBrakingOverTopSpeed;
        [FieldAttr(864)] public igVfxRangedCurveMetaField _stickAngleTurningPushCurve = new();
        [FieldAttr(948)] public igVfxRangedCurveMetaField _speedTurningPushCurve = new();
        [FieldAttr(1032)] public EVehicleSteeringMode _defaultSteeringMode = CBaseVehicleControllerComponentData.EVehicleSteeringMode.eVSM_Absolute;
        [FieldAttr(1036)] public igVfxRangedCurveMetaField _maxAngularSpeedCurve = new();
        [FieldAttr(1120)] public float _maxAngularSpeedCurveAbsoluteValue;
        [FieldAttr(1124)] public igVfxRangedCurveMetaField _angularTurningCurve = new();
        [FieldAttr(1208)] public float _angularTurningCurveAmplitude = 0.1f;
        [FieldAttr(1212)] public igVfxRangedCurveMetaField _angularAccelerationVelocityCurve = new();
        [FieldAttr(1296)] public igVfxRangedCurveMetaField _angularCoastingVelocityCurve = new();
        [FieldAttr(1380)] public igVfxRangedCurveMetaField _angularBrakingVelocityCurve = new();
        [FieldAttr(1464)] public float _turningLookAheadTime = 0.25f;
        [FieldAttr(1468)] public float _minimumSpeedForTurning;
        [FieldAttr(1472)] public float _steeringOverrideTowardsSplineMultiplier = 10.0f;
        [FieldAttr(1476)] public float _steeringOverrideTowardsSplineAngularThreshold = 10.0f;
        [FieldAttr(1480)] public float _steeringOverrideTowardsSplineMaxDuration = 2.0f;
        [FieldAttr(1484)] public bool _steeringOverrideUseSplineUpAsGuideForRotation;
        [FieldAttr(1488)] public float _boostOverrideTurningSpeed = 200.0f;
        [FieldAttr(1492)] public float _boostOverrideTurningLookAheadTime = 0.25f;
        [FieldAttr(1496)] public float _boostSteeringOverrideDecayScale = 1.0f;
        [FieldAttr(1500)] public bool _allowRelativeControls;
        [FieldAttr(1504)] public CShape? _debrisColliderShape;
        [FieldAttr(1512)] public float highSpeedRatio = 0.75f;
        [FieldAttr(1520)] public igHandleMetaField _highSpeedForceEffect = new();
        [FieldAttr(1528)] public CBoltPoint? _highSpeedDebrisLeftWheelBolt;
        [FieldAttr(1536)] public CBoltPoint? _highSpeedDebrisRightWheelBolt;
        [FieldAttr(1544)] public CShape? _highSpeedDebrisColliderShape;
        [FieldAttr(1552)] public string? _raceAiPlayerContactSound = null;
        [FieldAttr(1560)] public igHandleMetaField _accelerationLowToHighSound = new();
        [FieldAttr(1568)] public igHandleMetaField _accelerationHighToLowSound = new();
        [FieldAttr(1576)] public igHandleMetaField _overrideMotionProperties = new();
        [FieldAttr(1584)] public igVec3fMetaField _localInertiaMultiplier = new();
        [FieldAttr(1596)] public igVec3fMetaField _centerOfMassLocal = new();
        [FieldAttr(1608)] public igVec3fMetaField _rootOffset = new();
        [FieldAttr(1620)] public bool _debug;
        [FieldAttr(1621)] public bool _dirty;
        [FieldAttr(1624)] public float _driftOutTime = 0.5f;
        [FieldAttr(1628)] public EXBUTTON _accelerateButton = EXBUTTON.R2;
        [FieldAttr(1632)] public EXBUTTON _altAccelerateButton = EXBUTTON.MAX;
        [FieldAttr(1636)] public float _addedBoostAcceleration = 2000.0f;
        [FieldAttr(1640)] public float _switchAccelerateModeSpeed = 100.0f;
        [FieldAttr(1644)] public float _envCollisionSplineLookAheadDistance = 2000.0f;
        [FieldAttr(1648)] public float _collisionPushCooldown;
        [FieldAttr(1652)] public float _reorientationRayRadius = 100.0f;
        [FieldAttr(1656)] public int _reorientationRaycastWaitFrames = 5;
        [FieldAttr(1660)] public float _epicJumpModelReorientTime = 0.25f;
        [FieldAttr(1664)] public EXBUTTON _rearViewButton = EXBUTTON.L1;
        [FieldAttr(1668)] public float _maxSpeedDeltaFollowDistance;
        [FieldAttr(1672)] public float _maxSpeedDeltaFollowHeight;
        [FieldAttr(1676)] public float _maxSpeedDeltaFov;
        [FieldAttr(1680)] public SpeedVfxSpecList? _speedVfxs;
        [FieldAttr(1688)] public EVehicleAccelerateMode _defaultAccelerationMode = CBaseVehicleControllerComponentData.EVehicleAccelerateMode.eVAM_Button;
        [FieldAttr(1692)] public float _easySpeedMultiplier = 0.75f;
        [FieldAttr(1696)] public float _hardSpeedMultiplier = 1.5f;
        [FieldAttr(1700)] public float _easyBoostMultiplier = 1.25f;
        [FieldAttr(1704)] public float _hardBoostMultiplier = 0.75f;
        [FieldAttr(1708)] public bool _useWorldSpaceDragInAir;
        [FieldAttr(1712)] public float _landLinearSideDrag = 0.1f;
        [FieldAttr(1716)] public float _landLinearUpDrag = 0.01f;
        [FieldAttr(1720)] public float _landLinearDownDrag = 0.05f;
        [FieldAttr(1724)] public float _landAngularPitchRollDrag = 0.15f;
        [FieldAttr(1728)] public float _airLinearSideDrag = 0.01f;
        [FieldAttr(1732)] public float _airLinearUpDrag = 0.01f;
        [FieldAttr(1736)] public float _airLinearDownDrag = 0.01f;
        [FieldAttr(1740)] public float _airAngularPitchRollDrag = 0.01f;
        [FieldAttr(1744)] public float _maxKnockawayPitch = 5.0f;
        [FieldAttr(1748)] public float _maxKnockawayRoll = 5.0f;
        [FieldAttr(1752)] public float _knockawayResetAngleDamping = 0.1f;
        [FieldAttr(1756)] public float _maxKnockawayPitchAir = 45.0f;
        [FieldAttr(1760)] public float _maxKnockawayRollAir = 45.0f;
        [FieldAttr(1764)] public float _knockawayResetAngleDampingAir = 0.25f;
        [FieldAttr(1768)] public float _maxKnockawayAngularSpeed = 450.0f;
        [FieldAttr(1772)] public float _knockawayAirDistanceThreshold = 100.0f;
    }
}
