namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CSplineEvent : igSplineEvent
    {
        [FieldAttr(32)] public CSplineEventDelegate? _onSplineEvent;
        [FieldAttr(40)] public CSplineEventDelegateEventList? _onSplineEventList;
    }
}
