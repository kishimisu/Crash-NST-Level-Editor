namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_AlwaysOnData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _IdleSound = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _CrashDeath = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _IdleVfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
