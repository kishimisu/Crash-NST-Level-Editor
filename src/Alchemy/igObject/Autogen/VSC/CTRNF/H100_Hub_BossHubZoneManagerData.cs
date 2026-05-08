namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class H100_Hub_BossHubZoneManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int_0x20;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool;
        [FieldAttr(nst: 60, ctr: 52)] public int _Int_0x34;
    }
}
