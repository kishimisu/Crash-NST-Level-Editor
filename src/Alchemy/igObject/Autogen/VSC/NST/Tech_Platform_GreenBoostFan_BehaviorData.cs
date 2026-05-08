namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class Tech_Platform_GreenBoostFan_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _Bounce_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bounce_Vfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _Bounce_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Bounce_Sfx = new();
    }
}
