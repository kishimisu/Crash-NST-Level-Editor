namespace Alchemy
{
    [ObjectAttr(24, 8)]
    public class igDotNetHandle : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _handle = new();
    }
}
