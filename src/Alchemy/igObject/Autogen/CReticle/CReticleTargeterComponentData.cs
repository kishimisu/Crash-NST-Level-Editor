namespace Alchemy
{
    [ObjectAttr(368, 16)]
    public class CReticleTargeterComponentData : CEntityComponentData
    {
        public enum ENoTargetAimType : uint
        {
            eNTAT_IntoScreen = 0,
            eNTAT_EntityScreenRelative = 1,
            eNTAT_EntityPlaneRelative = 2,
        }

        public enum ENoTargetAimDistanceType : uint
        {
            eNTADT_TargetingDistance = 0,
            eNTADT_ReticlePosition = 1,
        }

        [FieldAttr(24)] public igHandleMetaField _primaryReticleEffect = new();
        [FieldAttr(32)] public igHandleMetaField _primaryReticleEffectTargetAcquired = new();
        [FieldAttr(40)] public igHandleMetaField _primaryReticleEffectP1 = new();
        [FieldAttr(48)] public igHandleMetaField _primaryReticleEffectP2 = new();
        [FieldAttr(56)] public igHandleMetaField _primaryReticleEffectAlt = new();
        [FieldAttr(64)] public igHandleMetaField _primaryReticleEffectAltP1 = new();
        [FieldAttr(72)] public igHandleMetaField _primaryReticleEffectAltP2 = new();
        [FieldAttr(80)] public EPlayerAttackType _altPrimaryReticlePlayerAttack = EPlayerAttackType.ePAT_Count;
        [FieldAttr(84)] public bool _usePrimaryReticleBolt;
        [FieldAttr(88)] public CBoltPoint? _primaryReticleBolt;
        [FieldAttr(96)] public float _primaryReticleScale = 1.0f;
        [FieldAttr(100)] public bool _keepConstantSize = true;
        [FieldAttr(112)] public igVec4fMetaField _defaultReticleColor = new();
        [FieldAttr(128)] public igVec4fMetaField _playerOneReticleColor = new();
        [FieldAttr(144)] public igVec4fMetaField _playerTwoReticleColor = new();
        [FieldAttr(160)] public igVec4fMetaField _targetAcquiredReticleColor = new();
        [FieldAttr(176)] public igHandleMetaField _secondaryReticleEffect = new();
        [FieldAttr(184)] public CBoltPoint? _secondaryReticleBolt;
        [FieldAttr(192)] public igHandleMetaField _lockReticleEffect = new();
        [FieldAttr(200)] public CBoltPoint? _lockReticleBolt;
        [FieldAttr(208)] public EPlayerAttackType _inactiveDuringPlayerAttack = EPlayerAttackType.ePAT_Count;
        [FieldAttr(212)] public EPlayerAttackType _activeOnlyDuringPlayerAttack = EPlayerAttackType.ePAT_Count;
        [FieldAttr(216)] public CScreenspaceTargetManager.EScreenspaceTargetListType _targetListType;
        [FieldAttr(224)] public CReticleTargeterDifficultyData? _difficultyData;
        [FieldAttr(232)] public CScreenspaceTarget.EScreenspaceTargetShape _targetShape = CScreenspaceTarget.EScreenspaceTargetShape.eSSTS_Circle;
        [FieldAttr(236)] public igVec2fMetaField _boxAcquireTargetingExtents = new();
        [FieldAttr(244)] public igVec2fMetaField _boxDropTargetingExtents = new();
        [FieldAttr(252)] public float _circleAcquireTargetingRadius = 40.0f;
        [FieldAttr(256)] public float _circleDropTargetingRadius;
        [FieldAttr(260)] public float _maxSeparationDepth = 1.0f;
        [FieldAttr(264)] public float _targetingMinKeepTargetDepth;
        [FieldAttr(268)] public float _targetingDistance = 1.0f;
        [FieldAttr(272)] public float _maxTargetingAcquireDistance = 12000.0f;
        [FieldAttr(276)] public float _screenspaceMaxTargetingRangeMultiplier = 1.0f;
        [FieldAttr(280)] public float _targetingClampPadding;
        [FieldAttr(284)] public bool _allowTargetingBehindVehicle;
        [FieldAttr(288)] public float _reticleVisibilityDuration = 3.0f;
        [FieldAttr(292)] public bool _reticleVisibilityEnabled = true;
        [FieldAttr(293)] public bool _reticleVisibleAtStart;
        [FieldAttr(296)] public EXBUTTON _fireButton = EXBUTTON.X;
        [FieldAttr(300)] public EXBUTTON _hideButton = EXBUTTON.MAX;
        [FieldAttr(304)] public CQueryFilter? _filterTargets;
        [FieldAttr(312)] public ECombatTargetList _targetList;
        [FieldAttr(316)] public bool _targetingSquareStickInput = true;
        [FieldAttr(317)] public bool _passengerTargeting;
        [FieldAttr(318)] public bool _gunnerTargeting;
        [FieldAttr(320)] public float _maxHorizontalReticleSpeed = 1.0f;
        [FieldAttr(324)] public float _maxVerticalReticleSpeed = 1.0f;
        [FieldAttr(328)] public float _reticleScreenEdgeOffset = 0.05f;
        [FieldAttr(332)] public bool _onlyUpdateLockedTargetOnInput;
        [FieldAttr(333)] public bool _dropTargetIfReticleMovesOffTarget;
        [FieldAttr(336)] public ENoTargetAimType _noTargetAimType;
        [FieldAttr(340)] public ENoTargetAimDistanceType _noTargetAimDistanceType;
        [FieldAttr(344)] public float _entityRelativeRayLength = 2.0f;
        [FieldAttr(348)] public bool _externalSystemReticleControl;
        [FieldAttr(352)] public float _externalOffset = 8000.0f;
        [FieldAttr(356)] public float _reticleWorldPositionDampingFactor = 0.5f;
    }
}
