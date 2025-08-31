namespace Alchemy
{
    // VSC object extracted from: Hazard_Bolted_Crushing_Objects_Behavior.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class Hazard_Bolted_Crushing_Objects_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public string? _CrashDeath = null;
        [FieldAttr(48)] public float _Float;
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(88)] public bool _Bool_0x58;
        [FieldAttr(89)] public bool _Bool_0x59;
        [FieldAttr(90)] public bool _Bool_0x5a;
    }
}
