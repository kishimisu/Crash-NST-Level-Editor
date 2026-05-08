namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Factory_Gate_RaisingData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _OpenGateTriggerVolume = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CloseGateTriggerVolume = new();
        [FieldAttr(nst: 56, ctr: 48)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound_0x58 = new();
    }
}
