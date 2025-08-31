namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CFilterEntities : igObject
    {
        [FieldAttr(16)] public CFilterMethodList? _filterMethods;
        [FieldAttr(24)] public CFilterMethodTable? _filterMethodTable;
    }
}
