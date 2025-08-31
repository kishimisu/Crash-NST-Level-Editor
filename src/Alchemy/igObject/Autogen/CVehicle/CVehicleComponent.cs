namespace Alchemy
{
    [ObjectAttr(288, 8)]
    public class CVehicleComponent : CEntityComponent
    {
        public enum EVehicleMode : uint
        {
            eVM_None = 0,
            eVM_Arena = 1,
            eVM_Linear = 2,
            eVM_Classic = 3,
            eVM_Expedition = 4,
        }

        public enum EVehicleForm : int
        {
            eVF_None = -1,
            eVF_Invisible = 0,
            eVF_Spawning = 1,
            eVF_Parked = 2,
            eVF_UnDocking = 3,
            eVF_Driving = 4,
            eVF_Docking = 5,
            eVF_Disembarking = 6,
            eVF_ExitingTrack = 7,
        }

        public enum EVehicleSplineState : int
        {
            eVSS_None = -1,
            eVSS_BasicSpline = 0,
            eVSS_HalfPipe = 1,
        }

        [FieldAttr(48)] public EVehicleForm _form = CVehicleComponent.EVehicleForm.eVF_None;
        [FieldAttr(52)] public EVehicleMode _mode;
        [FieldAttr(56)] public EPlayerId _driverId = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(60)] public EPlayerId _passengerId = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(64)] public EVehicleId _vehicleId = EVehicleId.EVEHICLEID_NONE;
        [FieldAttr(72)] public igHandleMetaField _driverPlayer = new();
        [FieldAttr(80)] public igHandleMetaField _passengerPlayer = new();
        [FieldAttr(88)] public igVec3fMetaField _passengerExitPoint = new();
        [FieldAttr(100)] public EVehicleMode _pendingMode;
        [FieldAttr(104)] public EVehicleForm _pendingForm = CVehicleComponent.EVehicleForm.eVF_None;
        [FieldAttr(112)] public CEntityComponentHandleList? _modeSpecificComponents;
        [FieldAttr(120)] public CEntityComponentHandleList? _arenaModeSpecificComponents;
        [FieldAttr(128)] public CEntityComponentHandleList? _linearModeSpecificComponents;
        [FieldAttr(136)] public CEntityComponentHandleList? _classicModeSpecificComponents;
        [FieldAttr(144)] public CEntityComponentHandleList? _expeditionModeSpecificComponents;
        [FieldAttr(152)] public COnFormChangeDelegate? _onFormChange;
        [FieldAttr(160)] public COnFormChangeEventList? _onFormChangeEventList;
        [FieldAttr(168)] public COnModeChangeDelegate? _onModeChange;
        [FieldAttr(176)] public COnModeChangeEventList? _onModeChangeEventList;
        [FieldAttr(184)] public COnVehiclePlayerChangeDelegate? _onVehiclePlayerChange;
        [FieldAttr(192)] public COnVehiclePlayerChangeEventList? _onVehiclePlayerChangeEventList;
        [FieldAttr(200)] public COnLockChangeEventList? _onLockChangeEventList;
        [FieldAttr(208)] public igHandleMetaField _transitionVfx = new();
        [FieldAttr(216)] public EVehicleMode _startingMode;
        [FieldAttr(220)] public bool _isVehicleTargetingStarted;
        [FieldAttr(221)] public bool _magicMomentDisabled;
        [FieldAttr(224, false)] public CVehicleBoostData? _transformBoostData;
        [FieldAttr(232)] public bool _initialized;
        [FieldAttr(233)] public bool _forwardTransformMomentumActive;
        [FieldAttr(234)] public bool _forwardTransformMomentumUseAlt;
        [FieldAttr(236)] public float _forwardTransformMomentum;
        [FieldAttr(240)] public float _forwardTransformMomentumAlt;
        [FieldAttr(248)] public CChangeRequestList? _changeRequests;
        [FieldAttr(256)] public bool _vehicleCombatEnabled = true;
        [FieldAttr(257)] public bool _vehicleHavokEnabled = true;
        [FieldAttr(258)] public bool _vehicleMovementEnabled = true;
        [FieldAttr(259)] public bool _vehicleBoltedToDock;
        [FieldAttr(264)] public igHandleMetaField _vehicleBolter = new();
        [FieldAttr(272)] public EVehicleSplineState _vehicleSplineState = CVehicleComponent.EVehicleSplineState.eVSS_None;
        [FieldAttr(276)] public bool _locked;
        [FieldAttr(280)] public EVehicleMode _lockedMode;
        [FieldAttr(284)] public bool _allowFiringModeEnterEvents;
    }
}
