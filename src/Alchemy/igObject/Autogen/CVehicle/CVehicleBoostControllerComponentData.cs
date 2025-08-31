namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class CVehicleBoostControllerComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public int _loopingBoostVfxLayer = 2;
        [FieldAttr(28)] public int _startBoostVfxLayer = 3;
        [FieldAttr(32)] public float _startBoostVfxTime = 1.0f;
        [FieldAttr(36)] public float _boostDeltaFollowDistance = -320.0f;
        [FieldAttr(40)] public float _boostDeltaFollowHeight = -4.0f;
        [FieldAttr(44)] public float _boostDeltaFov = 38.0f;
        [FieldAttr(48)] public float _boostRatioDampingFactor = 0.2f;
        [FieldAttr(56)] public CLoopingVfxComponentData? _loopingVfxComponentData;
        [FieldAttr(64)] public CBoltPoint? _boostVfxBoltPoint;
        [FieldAttr(72)] public CBoltPoint? _boostVfxBoltPoint2;
        [FieldAttr(80)] public igHandleMetaField _linearBoostVfxToSpawn = new();
        [FieldAttr(88)] public igHandleMetaField _linearPlayerBoostVfxToSpawn = new();
        [FieldAttr(96)] public igHandleMetaField _arenaBoostVfxToSpawn = new();
        [FieldAttr(104)] public igHandleMetaField _arenaPlayerBoostVfxToSpawn = new();
        [FieldAttr(112)] public igHandleMetaField _expeditionBoostVfxToSpawn = new();
        [FieldAttr(120)] public igHandleMetaField _expeditionPlayerBoostVfxToSpawn = new();
        [FieldAttr(128)] public igHandleMetaField _boostRumbleData = new();
    }
}
