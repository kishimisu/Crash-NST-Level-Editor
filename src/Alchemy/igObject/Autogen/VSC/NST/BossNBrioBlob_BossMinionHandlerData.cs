namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrioBlob_BossMinionHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _OnContactDamageData = new();
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _OnTakeHitSpinExitFallEaseType;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DamageBossProjectileData = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _OnTakeHitSpinStopMomentumDelay;
        [FieldAttr(nst: 68, ctr: 60)] public float _OnTakeHitSpinExitFallSpeed;
        [FieldAttr(nst: 72, ctr: 64)] public float _OnTakeHitSpinExitFallEaseRatioIn;
        [FieldAttr(nst: 76, ctr: 68)] public float _OnTakeHitSpinExitFallEaseRatioOut;
        [FieldAttr(nst: 80, ctr: 72)] public float _CrashSpinPushAwayMaxHeight_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _RestTime;
        [FieldAttr(nst: 88, ctr: 80)] public float _JumpToPlayerInitialDelay;
        [FieldAttr(nst: 92, ctr: 84)] public float _JumpToPlayerHeight;
        [FieldAttr(nst: 96, ctr: 88)] public float _JumpToPlayerTime;
        [FieldAttr(nst: 100, ctr: 92)] public float _JumpToPlayerDelay;
        [FieldAttr(nst: 104, ctr: 96)] public float _JumpTurnTime_0x68;
        [FieldAttr(nst: 108, ctr: 100)] public float _CrashSpinPushAwayForce;
        [FieldAttr(nst: 112, ctr: 104)] public int _JumpToPlayerCount;
        [FieldAttr(nst: 116, ctr: 108)] public float _JumpTurnTime_0x74;
        [FieldAttr(nst: 120, ctr: 112)] public float _CrashSpinPushAwayMaxHeight_0x78;
        [FieldAttr(nst: 124, ctr: 116)] public float _Float;
    }
}
