namespace Alchemy
{
    // VSC object extracted from: Hazard_AlwaysOn_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class Hazard_AlwaysOnData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _IdleSound = new();
        [FieldAttr(48)] public string? _CrashDeath = null;
        [FieldAttr(56)] public igHandleMetaField _IdleVfx = new();
        [FieldAttr(64)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
