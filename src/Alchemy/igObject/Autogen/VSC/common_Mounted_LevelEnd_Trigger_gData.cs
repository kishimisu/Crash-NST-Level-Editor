namespace Alchemy
{
    // VSC object extracted from: common_Mounted_LevelEnd_Trigger_g.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class common_Mounted_LevelEnd_Trigger_gData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(48)] public bool _IsDebugOn;
        [FieldAttr(56)] public string? _BehaviorEventCrashTeleportOutStart = null;
        [FieldAttr(64)] public igHandleMetaField _Entity = new();
        [FieldAttr(72)] public float _MoveCrashCenterEaseRatioIn;
        [FieldAttr(76)] public float _MoveCrashCenterTime;
        [FieldAttr(80)] public float _MoveCrashCenterEaseRatioOut;
        [FieldAttr(84)] public EigEaseType _MoveCrashCenterEaseType;
        [FieldAttr(88)] public float _Float;
    }
}
