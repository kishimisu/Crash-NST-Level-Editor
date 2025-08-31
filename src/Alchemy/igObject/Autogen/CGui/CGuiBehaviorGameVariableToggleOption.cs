namespace Alchemy
{
    [ObjectAttr(224, 8)]
    public class CGuiBehaviorGameVariableToggleOption : CGuiBehaviorBaseToggleOption
    {
        [FieldAttr(216)] public igHandleMetaField _toggledVariable = new();
    }
}
