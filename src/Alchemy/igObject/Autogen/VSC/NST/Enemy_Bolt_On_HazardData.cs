namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Bolt_On_HazardData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x38 = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool_0x48;
        [FieldAttr(nst: 73, ctr: 65)] public bool _Bool_0x49;
        [FieldAttr(nst: 74, ctr: 66)] public bool _Bool_0x4a;
        [FieldAttr(nst: 75, ctr: 67)] public bool _Bool_0x4b;
    }
}
