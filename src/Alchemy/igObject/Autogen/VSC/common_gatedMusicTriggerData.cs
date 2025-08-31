namespace Alchemy
{
    // VSC object extracted from: common_gatedMusicTrigger_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_gatedMusicTriggerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _StartDisabled;
        [FieldAttr(48)] public igHandleMetaField _OtherBox = new();
        [FieldAttr(56)] public igHandleMetaField _MusicSettings = new();
    }
}
