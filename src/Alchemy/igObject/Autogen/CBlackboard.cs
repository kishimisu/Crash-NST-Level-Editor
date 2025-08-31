namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBlackboard : igObject
    {
        [FieldAttr(16)] public CBlackboardInfoTable? _blackboardInfoTable;
        [FieldAttr(24)] public CBlackboardInfoUpdaterList? _blackboardInfoUpdaterList;
    }
}
