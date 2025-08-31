namespace Alchemy
{
    [ObjectAttr(264, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_ControlExternalEntityHandler : CBehaviorLogic
    {
        public enum ExternalControlMode : uint
        {
            Physics = 0,
            FollowGroundXY = 1,
            Actor = 2,
        }

        [FieldAttr(80)] public bool CreatingEntity = true;
        [FieldAttr(81)] public bool AllowAirCreation;
        [FieldAttr(82)] public bool DespawnCreatedEntity = true;
        [FieldAttr(84)] public float InitialDistance = 100.0f;
        [FieldAttr(88)] public CGameEntityData? ControlledEntity;
        [FieldAttr(96)] public float TimeToTurnToDirection = -1.0f;
        [FieldAttr(100)] public igEntity.ENetworkSpawnAuthority NetAuthority;
        [FieldAttr(104)] public bool SendMessagesToControlledEntity;
        [FieldAttr(105)] public bool SendControlledEntityCreatedMessage;
        [FieldAttr(106)] public bool SendControlledEntityRemovedMessage;
        [FieldAttr(107)] public bool SendMaxDistanceReachedMessage;
        [FieldAttr(108)] public bool SendControlExternalEntityEndMessage;
        [FieldAttr(109)] public bool SendFailureToCreateMessage;
        [FieldAttr(110)] public bool SendCreatedEntityEvent;
        [FieldAttr(112)] public CCustomEvent? StartControllingEntityEvent;
        [FieldAttr(120)] public CCustomEvent? StopControllingEntityEvent;
        [FieldAttr(128)] public CCustomEvent? ControlledEntityCreatedEvent;
        [FieldAttr(136)] public CCustomEvent? ControlledEntityRemovedEvent;
        [FieldAttr(144)] public CCustomEvent? MaxDistanceReachedEvent;
        [FieldAttr(152)] public CCustomEvent? ControlExternalEntityEndEvent;
        [FieldAttr(160)] public CCustomEvent? FailureToCreateEvent;
        [FieldAttr(168)] public CCustomEventEntity? CreatedEntityEvent;
        [FieldAttr(176)] public float MaxDistance;
        [FieldAttr(180)] public float MinDistance;
        [FieldAttr(184)] public CUpgradeableFloat? SpeedModifierUpgradeable;
        [FieldAttr(192)] public Vector3? Gravity;
        [FieldAttr(200)] public ExternalControlMode ControlMode;
        [FieldAttr(204)] public bool ForceForward;
        [FieldAttr(205)] public bool ForceFowardFullSpeed;
        [FieldAttr(206)] public bool AddSpeedWithInputWhenForceForward;
        [FieldAttr(208)] public float MaxAngleValue = 360.0f;
        [FieldAttr(212)] public float MaxFollowHeight = 1000.0f;
        [FieldAttr(216)] public float MinFollowHeight = -400.0f;
        [FieldAttr(220)] public float ZOffset;
        [FieldAttr(224)] public float MaxHeightDisplacement = 1000.0f;
        [FieldAttr(228)] public bool FaceControlledEntity;
        [FieldAttr(232)] public float TimeToTurn = 0.1f;
        [FieldAttr(236)] public float FaceDeadZone;
        [FieldAttr(240)] public string? ExternalControlEndEvent = null;
        [FieldAttr(248)] public CEntityMessage? ExternalControlEndMessage;
        [FieldAttr(256)] public bool UseRightStick;
    }
}
