namespace Alchemy
{
    // VSC object extracted from: C2_IrisDoor_Behavior.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class C2_IrisDoor_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public string? _String_0x28 = null;
        [FieldAttr(48)] public string? _String_0x30 = null;
        [FieldAttr(56)] public string? _String_0x38 = null;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Sound_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Entity_0x58 = new();
        [FieldAttr(96)] public bool _Bool;
        [FieldAttr(104)] public igHandleMetaField _Entity_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Checkpoint = new();
    }
}
