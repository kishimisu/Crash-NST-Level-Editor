namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Scuba_Hazard_MineData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Debug_Update_Channel = new();
    }
}
