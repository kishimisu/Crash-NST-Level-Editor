namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Floor_Spear_Spearhead_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _CrashDeath = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
    }
}
