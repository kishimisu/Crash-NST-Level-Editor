namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igLocalizedStringData : igObject
    {
        [FieldAttr(16)] public string? _string = null;
        [FieldAttr(24)] public igHandleMetaField _object = new();
        [FieldAttr(32)] public igStringMetaFieldInstance? _field;
    }
}
