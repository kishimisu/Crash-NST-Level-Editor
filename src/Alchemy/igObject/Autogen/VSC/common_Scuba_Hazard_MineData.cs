namespace Alchemy
{
    // VSC object extracted from: common_Scuba_Hazard_Mine.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_Scuba_Hazard_MineData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(44)] public float _Float_0x2c;
        [FieldAttr(48)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(56)] public float _Float_0x38;
        [FieldAttr(60)] public float _Float_0x3c;
        [FieldAttr(64)] public igHandleMetaField _Debug_Update_Channel = new();
    }
}
