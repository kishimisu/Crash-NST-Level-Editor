namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BossBehaviorSoundHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Behavior_State_Group = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
    }
}
