namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class L330_RingsOfPower_Race_TrackerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
    }
}
