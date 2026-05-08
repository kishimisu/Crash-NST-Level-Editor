namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class BossRipperRoo_StageHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
    }
}
