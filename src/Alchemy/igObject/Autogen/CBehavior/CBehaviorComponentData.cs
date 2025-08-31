namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CBehaviorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public string? _behaviorFile = null;
        [FieldAttr(32)] public string? _behaviorEventsFile = null;
        [FieldAttr(40)] public string? _startState = null;
        [FieldAttr(48)] public CBehaviorEventFilterData? _eventFilterData;
        [FieldAttr(56)] public CBehaviorLogicDataTable? _handlers;
    }
}
