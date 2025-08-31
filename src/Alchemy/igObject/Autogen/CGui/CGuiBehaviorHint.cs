namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CGuiBehaviorHint : CGuiBehaviorTimedMessage
    {
        [FieldAttr(64, false)] public igGuiAnimationTag? _scaleTextWidgetAnimation;
        [FieldAttr(72)] public igGuiAnimationCategory? _scaleTextWidgetAnimationCategory;
        [FieldAttr(80)] public float _maxTextWidth;
    }
}
