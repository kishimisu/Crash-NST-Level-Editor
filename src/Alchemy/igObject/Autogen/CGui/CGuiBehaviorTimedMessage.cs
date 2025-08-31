namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CGuiBehaviorTimedMessage : igGuiBehavior
    {
        [FieldAttr(16)] public CTimer? _timer;
        [FieldAttr(24)] public float _secondsActive;
        [FieldAttr(28)] public float _secondsAfterQueue = 1.0f;
        [FieldAttr(32, false)] public igGuiPlaceable? _textPlaceable;
        [FieldAttr(40, false)] public igGuiAnimationTag? _introAnimation;
        [FieldAttr(48, false)] public igGuiAnimationTag? _outroAnimation;
        [FieldAttr(56)] public ETimerType _durationType;
    }
}
