namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCESetBehaviorIntVariable : CCombatNodeEvent
    {
        [FieldAttr(80)] public string? _behaviorVariable = null;
        [FieldAttr(88)] public int _intValue;
    }
}
