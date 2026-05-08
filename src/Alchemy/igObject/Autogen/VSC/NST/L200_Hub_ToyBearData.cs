namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class L200_Hub_ToyBearData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Game_Bool_Variable_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Game_Bool_Variable_0x50 = new();
    }
}
