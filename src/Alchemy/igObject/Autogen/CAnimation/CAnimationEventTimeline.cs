namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CAnimationEventTimeline : CCharacterEventTimeline
    {
        [FieldAttr(32)] public bool _startAtCurrentTimeWhenActivated;
    }
}
