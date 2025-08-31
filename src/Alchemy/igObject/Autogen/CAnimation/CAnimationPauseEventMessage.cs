namespace Alchemy
{
    [ObjectAttr(104, 8, metaType: typeof(CAnimationPauseEventMessage))]
    public class CAnimationPauseEventMessage : CAnimationEventMessage
    {
        [FieldAttr(96)] public bool _isPaused;
    }
}
