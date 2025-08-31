namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGuiSaveSlotAnimations : igObject
    {
        [FieldAttr(16, false)] public igGuiAnimationTag? _beginAnimation;
        [FieldAttr(24, false)] public igGuiAnimationTag? _idleAnimation;
        [FieldAttr(32, false)] public igGuiAnimationTag? _endAnimation;
        [FieldAttr(40, false)] public igGuiAnimationTag? _endAnimationEmpty;
    }
}
