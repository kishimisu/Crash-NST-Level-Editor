namespace Alchemy
{
    [ObjectAttr(208, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_SpawnCollectiblesComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_SpawnCollectiblesComponent_
    {
        [FieldAttr(40)] public bool SpawnOnStartOnlyOnce;
        [FieldAttr(41)] public bool SpawnOnDeath;
        [FieldAttr(42)] public bool SpawnOnRemoveWhenDead;
        [FieldAttr(43)] public bool SpawnOnMessage;
        [FieldAttr(48)] public CEntityMessage? ReceivingMessage;
        [FieldAttr(56)] public Scripts_SpawnCollectiblesComponentData_CollectibleSelectionMethod? SeletionMethod;
        [FieldAttr(64)] public Scripts_SpawnCollectiblesComponentData_CollectibleSelectionMethod? VehicleSeletionMethod;
        [FieldAttr(72)] public RangedFloat? MaxCollectiblesToSpawn;
        [FieldAttr(80)] public float ChanceToSpawn = 1.0f;
        [FieldAttr(84)] public float Delay;
        [FieldAttr(88)] public float HorizontalAngularSpread = 360.0f;
        [FieldAttr(92)] public float HorizontalAngle;
        [FieldAttr(96)] public bool RotateTowardsPlayer;
        [FieldAttr(104)] public CBoltPoint? SpawnBoltPoint;
        [FieldAttr(112)] public Vector3? SpawnOffset;
        [FieldAttr(120)] public bool FaceCamera;
        [FieldAttr(124)] public int NumCollectiblesInWave = 1;
        [FieldAttr(128)] public RangedFloat? HorizontalVelocity;
        [FieldAttr(136)] public float HorizontalVelocityScaleAirVehicle = 1.0f;
        [FieldAttr(144)] public RangedFloat? VerticalVelocity;
        [FieldAttr(152)] public float VerticalVelocityScaleAirVehicle = 1.0f;
        [FieldAttr(160)] public Vector3? WorldDirectionalVelocity;
        [FieldAttr(168)] public igHandleMetaField SpawnSound = new();
        [FieldAttr(176)] public bool RemoveEntityWhenFinished;
        [FieldAttr(180)] public float RemoveEntityDelay;
        [FieldAttr(184)] public bool RemoveEntityWhenAllCollected;
        [FieldAttr(185)] public bool ForceCollect;
        [FieldAttr(192)] public RangedFloat? ForceCollectDelay;
        [FieldAttr(200)] public bool SynchronizeSpawnOnline;
    }
}
