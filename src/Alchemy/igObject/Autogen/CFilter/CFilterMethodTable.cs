namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CFilterMethodTable : igHashTable<string, igObject>
    {
        [FieldAttr(64)] public bool _isDirty;
    }
}
