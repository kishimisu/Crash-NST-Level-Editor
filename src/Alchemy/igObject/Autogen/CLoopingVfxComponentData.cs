namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CLoopingVfxComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _vfxEnabledOnStart = true;
        [FieldAttr(25)] public bool _requireSpecificVfxOnMessage;
        [FieldAttr(26)] public bool _hideVfxWhenEntityInvisible;
        [FieldAttr(27)] public bool _inhibitLooping;
        [FieldAttr(28)] public bool _respawnOnTeleport;
        [FieldAttr(32)] public igHandleMetaField _effect = new();
        [FieldAttr(40)] public igVfxManager.EffectKillType _effectKillType = igVfxManager.EffectKillType.kHardKill;
        [FieldAttr(48)] public CBoltPoint? _boltPoint;
        [FieldAttr(56)] public CBoltPoint? _boltPoint2;
        [FieldAttr(64)] public igHandleMetaField _boltEntity2 = new();
        [FieldAttr(72)] public CBaseVehicleModeFilter? _vehicleModeFilter;
    }
}
