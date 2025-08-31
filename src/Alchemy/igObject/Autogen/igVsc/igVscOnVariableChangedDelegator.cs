namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscOnVariableChangedDelegator : igVscDelegator
    {
        [FieldAttr(24)] public igVscAccessor? _target;
    }
}
