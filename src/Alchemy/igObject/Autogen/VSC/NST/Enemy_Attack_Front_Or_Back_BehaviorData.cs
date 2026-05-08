namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Attack_Front_Or_Back_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _deathClip = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Bolt_Point_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public string? _String_0x58 = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _String_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _String_0x70 = null;
    }
}
