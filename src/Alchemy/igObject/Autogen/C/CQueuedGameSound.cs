namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 56, align: 8)]
    public class CQueuedGameSound : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _sound = new();
        [FieldAttr(nst: 24, ctr: 24)] public igHandleMetaField _entity = new();
        [FieldAttr(nst: 32, ctr: 32)] public igVec3fMetaField _position = new();
        [FieldAttr(nst: 44, ctr: 44)] public igTimeMetaField _queuedTime = new();
        [FieldAttr(nst: 48, ctr: 48)] public igHandleMetaField _gameSoundInstance = new();
    }
}
