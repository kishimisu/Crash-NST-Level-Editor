namespace Alchemy
{
    // VSC object extracted from: BossNBrioBlob_BossMinionHandler_c.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class BossNBrioBlob_BossMinionHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _OnContactDamageData = new();
        [FieldAttr(48)] public EigEaseType _OnTakeHitSpinExitFallEaseType;
        [FieldAttr(56)] public igHandleMetaField _DamageBossProjectileData = new();
        [FieldAttr(64)] public float _OnTakeHitSpinStopMomentumDelay;
        [FieldAttr(68)] public float _OnTakeHitSpinExitFallSpeed;
        [FieldAttr(72)] public float _OnTakeHitSpinExitFallEaseRatioIn;
        [FieldAttr(76)] public float _OnTakeHitSpinExitFallEaseRatioOut;
        [FieldAttr(80)] public float _CrashSpinPushAwayMaxHeight_0x50;
        [FieldAttr(84)] public float _RestTime;
        [FieldAttr(88)] public float _JumpToPlayerInitialDelay;
        [FieldAttr(92)] public float _JumpToPlayerHeight;
        [FieldAttr(96)] public float _JumpToPlayerTime;
        [FieldAttr(100)] public float _JumpToPlayerDelay;
        [FieldAttr(104)] public float _JumpTurnTime_0x68;
        [FieldAttr(108)] public float _CrashSpinPushAwayForce;
        [FieldAttr(112)] public int _JumpToPlayerCount;
        [FieldAttr(116)] public float _JumpTurnTime_0x74;
        [FieldAttr(120)] public float _CrashSpinPushAwayMaxHeight_0x78;
        [FieldAttr(124)] public float _Float;
    }
}
