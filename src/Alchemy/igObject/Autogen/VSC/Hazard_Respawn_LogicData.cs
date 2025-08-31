namespace Alchemy
{
    // VSC object extracted from: Hazard_Respawn_Logic_c.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class Hazard_Respawn_LogicData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _DeathCamera = new();
        [FieldAttr(48)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(56)] public string? _OverrideFallingDeathClip = null;
        [FieldAttr(64)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(72)] public igHandleMetaField _Sound = new();
        [FieldAttr(80)] public bool _Bool;
    }
}
