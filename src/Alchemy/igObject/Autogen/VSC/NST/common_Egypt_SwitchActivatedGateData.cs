namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Egypt_SwitchActivatedGateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _CrashDeath = null;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound_0x50 = new();
    }
}
