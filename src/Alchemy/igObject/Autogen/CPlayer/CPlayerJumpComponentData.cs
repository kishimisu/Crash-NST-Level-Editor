namespace Alchemy
{
    [ObjectAttr(1680, 8)]
    public class CPlayerJumpComponentData : CEntityComponentData
    {
        public enum EPlayerJumpControl : uint
        {
            ePJC_Velocity = 0,
            ePJC_Curve = 1,
        }

        [FieldAttr(24)] public EPlayerJumpControl _playerJumpControl;
        [FieldAttr(28)] public float _tapJumpBoostPercentage;
        [FieldAttr(32)] public float _glitchJumpHeightBoost = 59.0f;
        [FieldAttr(36)] public float _glitchJumpRiseTimeBoost = 0.15f;
        [FieldAttr(40)] public float _glitchJumpFallTimeBoost = 0.1f;
        [FieldAttr(44)] public bool _glitchJumpEnabled;
        [FieldAttr(48)] public float _jumpMudScalar = 0.5f;
        [FieldAttr(52)] public float _jumpMudXYMovementScalar = 1.0f;
        [FieldAttr(56)] public igVfxRangedCurveMetaField _jumpTransitionCurve = new();
        [FieldAttr(140)] public igVfxRangedCurveMetaField _jumpPositionCurve = new();
        [FieldAttr(224)] public igVfxRangedCurveMetaField _fallingPositionCurve = new();
        [FieldAttr(308)] public float _curveJumpHeight = 110.0f;
        [FieldAttr(312)] public float _curveJumpRiseTime = 0.2f;
        [FieldAttr(316)] public float _curveJumpHeightCrash2 = 110.0f;
        [FieldAttr(320)] public float _curveJumpRiseTimeCrash2 = 0.2f;
        [FieldAttr(324)] public float _curveJumpHeightCrash3 = 110.0f;
        [FieldAttr(328)] public float _curveJumpRiseTimeCrash3 = 0.2f;
        [FieldAttr(332)] public float _curveTimeBeforeApexToPlayJumpToFall = 0.1f;
        [FieldAttr(336)] public float _curveFallTime = 0.33f;
        [FieldAttr(340)] public float _curveFallTimeCrash2 = 0.33f;
        [FieldAttr(344)] public float _curveFallTimeCrash3 = 0.33f;
        [FieldAttr(348)] public igVfxRangedCurveMetaField _jumpHeldPositionCurve = new();
        [FieldAttr(432)] public igVfxRangedCurveMetaField _jumpHeldFallingPositionCurve = new();
        [FieldAttr(516)] public float _heldCurveJumpHeight = 185.0f;
        [FieldAttr(520)] public float _heldCurveJumpHeightCrash2 = 185.0f;
        [FieldAttr(524)] public float _heldCurveJumpHeightCrash3 = 185.0f;
        [FieldAttr(528)] public float _heldCurveJumpRiseTime = 0.4f;
        [FieldAttr(532)] public float _heldCurveJumpRiseTimeCrash2 = 0.4f;
        [FieldAttr(536)] public float _heldCurveJumpRiseTimeCrash3 = 0.4f;
        [FieldAttr(540)] public float _heldCurveFallTime = 0.34999999f;
        [FieldAttr(544)] public float _heldCurveFallTimeCrash2 = 0.34999999f;
        [FieldAttr(548)] public float _heldCurveFallTimeCrash3 = 0.34999999f;
        [FieldAttr(552)] public igVfxRangedCurveMetaField _jumpCrouchPositionCurve = new();
        [FieldAttr(636)] public igVfxRangedCurveMetaField _jumpCrouchFallingPositionCurve = new();
        [FieldAttr(720)] public float _crouchCurveJumpHeight = 166.0f;
        [FieldAttr(724)] public float _crouchCurveJumpRiseTime = 0.4f;
        [FieldAttr(728)] public float _crouchCurveFallTime = 0.34999999f;
        [FieldAttr(732)] public igVfxRangedCurveMetaField _jumpCrouchHeldPositionCurve = new();
        [FieldAttr(816)] public igVfxRangedCurveMetaField _jumpCrouchHeldFallingPositionCurve = new();
        [FieldAttr(900)] public float _crouchHeldCurveJumpHeight = 166.0f;
        [FieldAttr(904)] public float _crouchHeldCurveJumpRiseTime = 0.4f;
        [FieldAttr(908)] public float _crouchHeldCurveFallTime = 0.34999999f;
        [FieldAttr(912)] public igVfxRangedCurveMetaField _jumpDoublePositionCurve = new();
        [FieldAttr(996)] public igVfxRangedCurveMetaField _jumpDoubleFallingPositionCurve = new();
        [FieldAttr(1080)] public float _doubleCurveJumpHeight = 170.0f;
        [FieldAttr(1084)] public float _doubleCurveJumpRiseTime = 0.328f;
        [FieldAttr(1088)] public float _doubleCurveFallTime = 0.25f;
        [FieldAttr(1092)] public igVfxRangedCurveMetaField _jumpDoubleHeldPositionCurve = new();
        [FieldAttr(1176)] public igVfxRangedCurveMetaField _jumpDoubleHeldFallingPositionCurve = new();
        [FieldAttr(1260)] public float _doubleHeldCurveJumpHeight = 190.0f;
        [FieldAttr(1264)] public float _doubleHeldCurveJumpRiseTime = 0.34999999f;
        [FieldAttr(1268)] public float _doubleHeldCurveFallTime = 0.32499999f;
        [FieldAttr(1272)] public float _spinAttackFallRateMultiplier = 1.0f;
        [FieldAttr(1276)] public float _curveTimeBeforeApexToAllowInput;
        [FieldAttr(1280)] public float _jumpInitialVelocity = 1400.0f;
        [FieldAttr(1284)] public float _jumpHoldGravity = -1500.0f;
        [FieldAttr(1288)] public float _jumpReleaseGravity = -1500.0f;
        [FieldAttr(1292)] public float _minJumpHoldTime;
        [FieldAttr(1296)] public bool _jumpAlongUpOfOwner;
        [FieldAttr(1297)] public bool _forceFlatLanding;
        [FieldAttr(1300)] public float _maxFlatLandingSlope = 45.0f;
        [FieldAttr(1304)] public float _flatLandingSupportRadius = 20.0f;
        [FieldAttr(1308)] public bool _forceSmoothWallCollisions;
        [FieldAttr(1312)] public float _minSmoothWallSlope = 50.0f;
        [FieldAttr(1316)] public float _fallGravity = -1350.0f;
        [FieldAttr(1320)] public float _fallMaxSpeed = -830.0f;
        [FieldAttr(1324)] public float _fallMaxSpeedCrash2 = -1400.0f;
        [FieldAttr(1328)] public float _fallMaxSpeedCrash3 = -1400.0f;
        [FieldAttr(1332)] public float _xyMovementSpeed = 460.0f;
        [FieldAttr(1336)] public float _xyMovementModifier = 50.0f;
        [FieldAttr(1340)] public float _xyMovementModifierThreshold = 420.0f;
        [FieldAttr(1344)] public float _xyMovementDamping = 0.89999998f;
        [FieldAttr(1348)] public float _forwardCosAngle;
        [FieldAttr(1352)] public bool _blockAirTurn;
        [FieldAttr(1353)] public bool _ignoreBlockingEdges;
        [FieldAttr(1356)] public float _forwardAirMovementInputThrottle = 7.0f;
        [FieldAttr(1360)] public float _backwardAirMovementInputThrottle = 2.0f;
        [FieldAttr(1364)] public float _curveMovementTime = 0.33f;
        [FieldAttr(1368)] public igVfxRangedCurveMetaField _movementControlCurve = new();
        [FieldAttr(1456)] public CActorInputMap? _airInputMap;
        [FieldAttr(1464)] public float _surfaceVelocityFadeTime = 0.5f;
        [FieldAttr(1468)] public bool _useSurfaceVelocity = true;
        [FieldAttr(1472)] public string? _airLocomotionState = "AirLocomotion";
        [FieldAttr(1480)] public string? _interactionsState = "SharedInteractions";
        [FieldAttr(1488)] public string? _knockAwayState = "HitReacts_Knockaway";
        [FieldAttr(1496)] public string? _groundLocomotionState = "GroundLocomotion";
        [FieldAttr(1504)] public string? _spinAttackState = "Attack_SpinMaster";
        [FieldAttr(1512)] public string? _jumpState = "Jump";
        [FieldAttr(1520)] public string? _jumpToFallState = "JumpToFall";
        [FieldAttr(1528)] public string? _fallState = "Falling";
        [FieldAttr(1536)] public string? _bounceState = "WC_Bounce";
        [FieldAttr(1544)] public string? _landState = "Land";
        [FieldAttr(1552)] public string? _landRunState = "LandRun";
        [FieldAttr(1560)] public float _forwardTurnRateScale = 0.5f;
        [FieldAttr(1564)] public float _backwardTurnRateScale = 0.1f;
        [FieldAttr(1568)] public float _crateTurnRateScale = 0.5f;
        [FieldAttr(1576)] public CGameBoolVariable? _doubleJumpEnabled;
        [FieldAttr(1584)] public bool _killXYVelocityOnDoubleJump = true;
        [FieldAttr(1588)] public float _doubleJumpFallWindow = 40.0f;
        [FieldAttr(1592)] public float _doubleJumpBounceRiseWindow = 100.0f;
        [FieldAttr(1596)] public float _bounceHoldActiveDistance = 100.0f;
        [FieldAttr(1600)] public igHandleMetaField _doubleJumpVfx = new();
        [FieldAttr(1608)] public CFallSpeedModifierList? _fallSpeedModifiers;
        [FieldAttr(1616)] public string? _doubleJumpBehaviorSelectorVariable = "HighJumpSelector";
        [FieldAttr(1624)] public int _doubleJumpSelectorEnabledValue = 1;
        [FieldAttr(1628)] public int _doubleJumpSelectorDisabledValue;
        [FieldAttr(1632)] public float _minCeilingDistanceFromFeet = 68.0f;
        [FieldAttr(1636)] public float _landRunSpeedBumpScale = 0.66f;
        [FieldAttr(1640)] public float _experimentalXYMovementDamping = 0.25f;
        [FieldAttr(1644)] public float _experimentalXYBackwardMovementDamping = 0.1f;
        [FieldAttr(1648)] public igHandleMetaField _akuAkuInvincible = new();
        [FieldAttr(1656)] public float _akuAkuXyMovementSpeed = 460.0f;
        [FieldAttr(1660)] public float _akuAkuXyMovementSpeedCrash2 = 520.0f;
        [FieldAttr(1664)] public float _akuAkuXyMovementSpeedCrash3 = 520.0f;
        [FieldAttr(1668)] public float _sprintXyMovementSpeed = 664.29998779f;
        [FieldAttr(1672)] public float _sprintXyMovementSpeedCrash2 = 664.29998779f;
        [FieldAttr(1676)] public float _sprintXyMovementSpeedCrash3 = 664.29998779f;
    }
}
