namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CCEQueryCombatTargets : CCombatNodeEvent
    {
        [FieldAttr(80)] public CQueryFilter? _query;
        [FieldAttr(88)] public ECombatTargetList _targetList;
        [FieldAttr(96)] public CCombatNodeEvent? _successEvent;
        [FieldAttr(104)] public CCombatNodeEvent? _failEvent;
    }
}
