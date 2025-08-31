namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igLocalizedHashTable : igUnsignedIntStringHashTable
    {
        [FieldAttr(64)] public igHandleMetaField _object = new();
        [FieldAttr(72)] public igObject? _field;
    }
}
