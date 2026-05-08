namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_gatedMusicTriggerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _StartDisabled;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _OtherBox = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _MusicSettings = new();
    }
}
