namespace Alchemy
{
    // VSC object extracted from: common_Factory_Gate_c.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class common_Factory_GateData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _OpenGateTriggerVolume = new();
        [FieldAttr(48)] public igHandleMetaField _CloseGateTriggerVolume = new();
        [FieldAttr(56)] public igHandleMetaField _OpenGateTriggerVolume_BackEntrance = new();
        [FieldAttr(64)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(76)] public float _Float_0x4c;
        [FieldAttr(80)] public float _Float_0x50;
        [FieldAttr(84)] public float _Float_0x54;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public igHandleMetaField _Sound_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Sound_0x68 = new();
    }
}
