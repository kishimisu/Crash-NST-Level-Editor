namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CAnimationEventMessage))]
    public class CAnimationEventMessage : CEntityMessage
    {
        [FieldAttr(56)] public SAnimationPlaybackInfoMetaField _animationPlaybackInfo = new();
        [FieldAttr(88)] public string? _animationName = null;
    }
}
