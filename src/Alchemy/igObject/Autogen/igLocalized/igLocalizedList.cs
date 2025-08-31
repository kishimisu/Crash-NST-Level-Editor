namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igLocalizedList : igStringRefList
    {
        [FieldAttr(40)] public igHandleMetaField _object = new();
        [FieldAttr(48)] public igObject? _field;
    }
}
