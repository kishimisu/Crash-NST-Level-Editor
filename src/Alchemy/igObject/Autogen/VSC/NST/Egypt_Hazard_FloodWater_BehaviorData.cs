namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class Egypt_Hazard_FloodWater_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 44, ctr: 36)] public bool _Bool;
        [FieldAttr(nst: 48, ctr: 40)] public string? _CrashDeath = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_0x58 = new();
    }
}
