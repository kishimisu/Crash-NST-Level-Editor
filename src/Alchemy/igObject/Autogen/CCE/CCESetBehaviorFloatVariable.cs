namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCESetBehaviorFloatVariable : CCombatNodeEvent
    {
        [FieldAttr(80)] public string? _behaviorVariable = null;
        [FieldAttr(88)] public float _floatValue;
    }
}
