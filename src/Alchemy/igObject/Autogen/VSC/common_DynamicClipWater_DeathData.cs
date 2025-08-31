namespace Alchemy
{
    // VSC object extracted from: common_DynamicClipWater_Death.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class common_DynamicClipWater_DeathData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Sound = new();
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _DeathCamera = new();
        [FieldAttr(64)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(72)] public bool _Bool;
        [FieldAttr(80)] public string? _OverrideFallingDeathClip = null;
    }
}
