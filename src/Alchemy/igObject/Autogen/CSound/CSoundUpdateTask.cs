namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class CSoundUpdateTask : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _sound = new();
        [FieldAttr(nst: 24, ctr: 24)] public igHandleMetaField _owner = new();
    }
}
