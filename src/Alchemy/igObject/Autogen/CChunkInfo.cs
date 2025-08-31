namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CChunkInfo : igNamedObject
    {
        [FieldAttr(24)] public igHandleMetaField _budget = new();
    }
}
