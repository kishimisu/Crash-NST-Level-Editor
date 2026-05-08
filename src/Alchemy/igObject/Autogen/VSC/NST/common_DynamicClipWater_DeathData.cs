namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_DynamicClipWater_DeathData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DeathCamera = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool;
        [FieldAttr(nst: 80, ctr: 72)] public string? _OverrideFallingDeathClip = null;
    }
}
