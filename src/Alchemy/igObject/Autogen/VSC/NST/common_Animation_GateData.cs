namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Animation_GateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _CloseGateTriggerVolume = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _OpenGateTriggerVolume_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x38 = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _OpenGateTriggerVolume_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Sound_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
    }
}
