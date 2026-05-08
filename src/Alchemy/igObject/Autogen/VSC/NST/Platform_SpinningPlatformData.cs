namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class Platform_SpinningPlatformData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _ActiveTime;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Spin_Sfx = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _Warning = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _SpinDeath = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Idle = null;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Vfx_Effect_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect_0x70 = new();
    }
}
