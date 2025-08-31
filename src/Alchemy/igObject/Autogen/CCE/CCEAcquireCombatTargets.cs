namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CCEAcquireCombatTargets : CCombatNodeEvent
    {
        [FieldAttr(80)] public EAcquireInsertMethod _insertMethod;
        [FieldAttr(84)] public ECombatTargetList _targetList;
        [FieldAttr(88)] public CSortEntities? _sortMethod;
        [FieldAttr(96)] public CFilterEntities? _filterMethod;
        [FieldAttr(104)] public uint _targetType;
        [FieldAttr(108)] public float _radius = 100.0f;
        [FieldAttr(112)] public float _angle = 90.0f;
        [FieldAttr(120)] public CCombatNodeEvent? _successEvent;
        [FieldAttr(128)] public CCombatNodeEvent? _failEvent;
        [FieldAttr(136)] public bool _useDefaultTarget;
        [FieldAttr(140)] public igVec3fMetaField _defaultTargetOffset = new();
    }
}
