namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CQueryFilter : igObject
    {
        [FieldAttr(16)] public uint _typesToInclude;
        [FieldAttr(24)] public CFilterEntities? _filterMethods;
        [FieldAttr(32)] public EQuerySortMode _sortMode;
        [FieldAttr(40)] public CQueryFilter? _queryToAppend;
        [FieldAttr(48)] public bool _onlyConsiderEnabled = true;
    }
}
