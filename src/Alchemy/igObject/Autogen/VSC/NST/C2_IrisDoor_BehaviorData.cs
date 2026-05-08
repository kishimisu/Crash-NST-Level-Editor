namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class C2_IrisDoor_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x38 = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Entity_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Checkpoint = new();
    }
}
