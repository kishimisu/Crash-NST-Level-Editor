namespace Alchemy
{
    // VSC object extracted from: Platform_SpinningPlatform_c.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class Platform_SpinningPlatformData : CVscComponentData
    {
        [FieldAttr(40)] public float _ActiveTime;
        [FieldAttr(48)] public igHandleMetaField _Spin_Sfx = new();
        [FieldAttr(56)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(64)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(72)] public string? _Warning = null;
        [FieldAttr(80)] public string? _SpinDeath = null;
        [FieldAttr(88)] public string? _Idle = null;
        [FieldAttr(96)] public igHandleMetaField _Vfx_Effect_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Vfx_Effect_0x70 = new();
    }
}
