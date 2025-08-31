namespace Alchemy
{
    // VSC object extracted from: common_Factory_Gate_Raising.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class common_Factory_Gate_RaisingData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _OpenGateTriggerVolume = new();
        [FieldAttr(48)] public igHandleMetaField _CloseGateTriggerVolume = new();
        [FieldAttr(56)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(68)] public float _Float_0x44;
        [FieldAttr(72)] public float _Float_0x48;
        [FieldAttr(80)] public igHandleMetaField _Sound_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Sound_0x58 = new();
    }
}
