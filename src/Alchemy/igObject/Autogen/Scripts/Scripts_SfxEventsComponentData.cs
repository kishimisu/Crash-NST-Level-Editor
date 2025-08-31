namespace Alchemy
{
    [ObjectAttr(160, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_SfxEventsComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_SfxEventsComponent_
    {
        [FieldAttr(40)] public bool SoundIsStreamed;
        [FieldAttr(41)] public bool StopOnDeathRemove;
        [FieldAttr(42)] public bool StopSfxWithFade;
        [FieldAttr(43)] public bool NullSoundInstanceOnPlay;
        [FieldAttr(44)] public float TouchInterval;
        [FieldAttr(48)] public igHandleMetaField SfxOnAct = new();
        [FieldAttr(56)] public igHandleMetaField SfxOnActivate = new();
        [FieldAttr(64)] public igHandleMetaField SfxOnInit = new();
        [FieldAttr(72)] public igHandleMetaField SfxOnDamage = new();
        [FieldAttr(80)] public igHandleMetaField SfxOnDeath = new();
        [FieldAttr(88)] public igHandleMetaField SfxOnEnter = new();
        [FieldAttr(96)] public igHandleMetaField SfxOnExit = new();
        [FieldAttr(104)] public igHandleMetaField SfxOnTouch = new();
        [FieldAttr(112)] public igHandleMetaField SfxOnRemove = new();
        [FieldAttr(120)] public igHandleMetaField SfxOnMessage = new();
        [FieldAttr(128)] public CEntityMessage? ReceivingMessage;
        [FieldAttr(136)] public igHandleMetaField LoopingSfx = new();
        [FieldAttr(144)] public CEntityMessage? StartLoopMessage;
        [FieldAttr(152)] public CEntityMessage? StopLoopMessage;
    }
}
