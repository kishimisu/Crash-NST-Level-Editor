namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVscBehaviorStateEventOnEnterByNameDelegator : CVscBehaviorStateEventDelegator
    {
        [FieldAttr(32)] public igVscStringAccessor? _stateName;
    }
}
