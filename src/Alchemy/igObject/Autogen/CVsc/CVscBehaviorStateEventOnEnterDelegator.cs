namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVscBehaviorStateEventOnEnterDelegator : CVscBehaviorStateEventDelegator
    {
        [FieldAttr(32)] public igVscObjectAccessor? _state;
    }
}
