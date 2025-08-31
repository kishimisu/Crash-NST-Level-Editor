namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVscBehaviorStateEventOnExitGroupDelegator : CVscBehaviorStateEventDelegator
    {
        [FieldAttr(32)] public igVscObjectAccessor? _stateGroup;
    }
}
