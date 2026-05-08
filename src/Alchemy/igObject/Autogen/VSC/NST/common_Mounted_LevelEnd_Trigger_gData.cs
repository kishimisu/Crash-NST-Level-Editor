namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Mounted_LevelEnd_Trigger_gData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 48, ctr: 40)] public bool _IsDebugOn;
        [FieldAttr(nst: 56, ctr: 48)] public string? _BehaviorEventCrashTeleportOutStart = null;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _MoveCrashCenterEaseRatioIn;
        [FieldAttr(nst: 76, ctr: 68)] public float _MoveCrashCenterTime;
        [FieldAttr(nst: 80, ctr: 72)] public float _MoveCrashCenterEaseRatioOut;
        [FieldAttr(nst: 84, ctr: 76)] public EigEaseType _MoveCrashCenterEaseType;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float;
    }
}
