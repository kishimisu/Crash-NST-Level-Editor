namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVscBehaviorStateEventOnExitByNameDelegator : CVscBehaviorStateEventDelegator
    {
        [FieldAttr(32)] public igVscStringAccessor? _stateName;
    }
}
