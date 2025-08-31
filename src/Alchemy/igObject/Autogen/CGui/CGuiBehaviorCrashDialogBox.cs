namespace Alchemy
{
    [ObjectAttr(360, 8)]
    public class CGuiBehaviorCrashDialogBox : CGuiBehaviorDialogBox
    {
        [FieldAttr(280, false)] public igGuiAnimationTag? _crash1IntroAnimation;
        [FieldAttr(288, false)] public igGuiAnimationTag? _crash1IdleAnimation;
        [FieldAttr(296, false)] public igGuiAnimationTag? _crash1OutroAnimation;
        [FieldAttr(304, false)] public igGuiAnimationTag? _crash2IntroAnimation;
        [FieldAttr(312, false)] public igGuiAnimationTag? _crash2IdleAnimation;
        [FieldAttr(320, false)] public igGuiAnimationTag? _crash2OutroAnimation;
        [FieldAttr(328, false)] public igGuiAnimationTag? _crash3IntroAnimation;
        [FieldAttr(336, false)] public igGuiAnimationTag? _crash3IdleAnimation;
        [FieldAttr(344, false)] public igGuiAnimationTag? _crash3OutroAnimation;
        [FieldAttr(352)] public ECrashGame _overrideCrashGame;
    }
}
