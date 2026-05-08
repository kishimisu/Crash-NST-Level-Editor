namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Bolted_Crushing_Objects_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _CrashDeath = null;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public bool _Bool_0x58;
        [FieldAttr(nst: 89, ctr: 81)] public bool _Bool_0x59;
        [FieldAttr(nst: 90, ctr: 82)] public bool _Bool_0x5a;
    }
}
