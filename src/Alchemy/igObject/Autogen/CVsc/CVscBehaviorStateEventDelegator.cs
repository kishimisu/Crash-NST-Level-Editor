namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVscBehaviorStateEventDelegator : igVscDelegator
    {
        [FieldAttr(24)] public igVscObjectAccessor? _target;
    }
}
