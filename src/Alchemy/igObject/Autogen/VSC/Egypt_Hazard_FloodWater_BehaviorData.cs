namespace Alchemy
{
    // VSC object extracted from: Egypt_Hazard_FloodWater_Behavior.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class Egypt_Hazard_FloodWater_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float;
        [FieldAttr(44)] public bool _Bool;
        [FieldAttr(48)] public string? _CrashDeath = null;
        [FieldAttr(56)] public igHandleMetaField _Sound_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _Sound_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Entity_0x58 = new();
    }
}
