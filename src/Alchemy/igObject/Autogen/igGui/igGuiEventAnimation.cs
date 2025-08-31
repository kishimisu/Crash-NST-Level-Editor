namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGuiEventAnimation : igGuiEvent
    {
        [FieldAttr(24, false)] public igGuiAnimationTag? _animation;
    }
}
