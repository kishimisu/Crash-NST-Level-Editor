namespace Alchemy
{
    [ObjectAttr(576, 8)]
    public class CActor : CPhysicalEntity
    {
        [ObjectAttr(4)]
        public class NonPersistentBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _useCameraInputTransform = true;
            [FieldAttr(1, size: 1)] public bool _hasActorInputMapComponent;
            [FieldAttr(2, size: 1)] public bool _hasBaseVehicleControllerComponent = false;
            [FieldAttr(3, size: 1)] public bool _canDockTo = false;
            [FieldAttr(4, size: 1)] public bool _animClipDisplayHero;
            [FieldAttr(5, size: 1)] public bool _timelineDisplayHero;
        }

        [FieldAttr(296)] public float mPainSoundTimer;
        [FieldAttr(300)] public igTimeMetaField mDeathTime = new();
        [FieldAttr(304)] public CEntityIDMetaField mLastHitEnt = new();
        [FieldAttr(308)] public float mLastHitEntTime;
        [FieldAttr(312)] public float mLastAttackedTime;
        [FieldAttr(316)] public CEntityIDMetaField mLastAttackedBy = new();
        [FieldAttr(320)] public uint mAttackNumber;
        [FieldAttr(328)] public igHandleMetaField _player = new();
        [FieldAttr(336)] public NonPersistentBitfield _nonPersistentBitfield = new();
        [FieldAttr(340)] public bool mIsPlayerFastFlagHack;
        [FieldAttr(341)] public bool mInitialized;
        [FieldAttr(342)] public bool _inFreezeFrame;
        [FieldAttr(344)] public igVec3fMetaField _linearVelocityBeforeFreezeFrame = new();
        [FieldAttr(356)] public igVec3fMetaField _angularVelocityBeforeFreezeFrame = new();
        [FieldAttr(368)] public igVec2fMetaField _currentMoveStickDirection = new();
        [FieldAttr(376)] public CTransformMetaField _inputTransform = new();
        [FieldAttr(404)] public float _heroShadowFade = 1.0f;
        [FieldAttr(408)] public igHandleMetaField _lastGroundMaterialTouched = new();
        [FieldAttr(416)] public bool _debugMove;
        [FieldAttr(424)] public ActorInput? _actorInput;
        [FieldAttr(432)] public CEnableRequestManager? _ignoreHitReacts;
        [FieldAttr(440)] public CEnableRequestManager? _ignorePartialHitReacts;
        [FieldAttr(448)] public CEnableRequestManager? _ignoreHitPushBack;
        [FieldAttr(456)] public CTargetableFlagEnableStack? _targetableFlag;
        [FieldAttr(464)] public CActorTimeScaleNonRefcountedList? _timeScaleList;
        [FieldAttr(472)] public CTimeScaleEnableStack? _allowTimeScaling;
        [FieldAttr(480)] public CActorTimeScale? _freezeFrameTimeScale;
        [FieldAttr(488)] public CEnableRequestManager? _muted;
        [FieldAttr(496)] public CChangeRequestList? _changeRequests;
        [FieldAttr(504)] public string? _skinName = null;
        [FieldAttr(512)] public bool _followingOther;
        [FieldAttr(520, false)] public CActor? _followHero;
        [FieldAttr(528)] public igHandleMetaField _behaviorComponentHandle = new();
        [FieldAttr(536)] public CCombatTargetDataListList? _combatTargets;
        [FieldAttr(544)] public igHandleMetaField _combatTargetProxy = new();
        [FieldAttr(552)] public CCollectibleFilterList? _collectiblesFilters;
        [FieldAttr(560)] public igHandleMetaField _enabledBaseVehicleController = new();
        [FieldAttr(568)] public bool _canCollectCollectibles = true;
    }
}
