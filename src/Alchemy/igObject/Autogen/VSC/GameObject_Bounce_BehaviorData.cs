namespace Alchemy
{
    // VSC object extracted from: GameObject_Bounce_Behavior_c.igz

    [ObjectAttr(160, metaType: typeof(CVscComponentData))]
    public class GameObject_Bounce_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _HazardEnabled;
        [FieldAttr(44)] public float _BounceSpeed;
        [FieldAttr(48)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(56)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(64)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(72)] public string? _CrashDeath = null;
        [FieldAttr(80)] public string? _Bounce = null;
        [FieldAttr(88)] public string? _Idle = null;
        [FieldAttr(96)] public igHandleMetaField _Bounce_Vfx = new();
        [FieldAttr(104)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(112)] public igHandleMetaField _Entity_Tag_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(128)] public igHandleMetaField _Entity_Tag_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(144)] public igHandleMetaField _Sound = new();
        [FieldAttr(152)] public bool _Bool_0x98;
        [FieldAttr(153)] public bool _Bool_0x99;
    }
}
