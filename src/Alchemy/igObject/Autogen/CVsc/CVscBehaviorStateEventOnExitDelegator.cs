namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVscBehaviorStateEventOnExitDelegator : CVscBehaviorStateEventDelegator
    {
        [FieldAttr(32)] public igVscObjectAccessor? _state;
    }
}
