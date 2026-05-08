namespace Alchemy
{
    [ObjectAttr(nst: 160, ctr: 152, align: 4, metaType: typeof(CVscComponentData))]
    public class GameObject_Bounce_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _HazardEnabled;
        [FieldAttr(nst: 44, ctr: 36)] public float _BounceSpeed;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _CrashDeath = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Bounce = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Idle = null;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bounce_Vfx = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_Tag_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity_Tag_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 152, ctr: 144)] public bool _Bool_0x98;
        [FieldAttr(nst: 153, ctr: 145)] public bool _Bool_0x99;
    }
}
