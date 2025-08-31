namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CAIAggroRuleTable : igHashTable<string, igObject>
    {
        [FieldAttr(64)] public bool _isDirty;
        [FieldAttr(72)] public CAIAggroRuleList? _list;
    }
}
