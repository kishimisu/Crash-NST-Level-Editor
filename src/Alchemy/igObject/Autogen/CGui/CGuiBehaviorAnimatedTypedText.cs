namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CGuiBehaviorAnimatedTypedText : igGuiBehavior
    {
        public enum ETypingState : uint
        {
            eTS_Idle = 0,
            eTS_BeginAnimation = 1,
            eTS_Typing = 2,
            eTS_PerCharacterAnimation = 3,
            eTS_EndAnimation = 4,
        }

        [FieldAttr(16)] public CTimer? _timer;
        [FieldAttr(24)] public float _secondsPerCharacter;
        [FieldAttr(28)] public bool _isLooping;
        [FieldAttr(29)] public bool _clearOnLoad;
        [FieldAttr(32, false)] public igGuiAnimationTag? _beginTypeAnimation;
        [FieldAttr(40, false)] public igGuiAnimationTag? _endTypeAnimation;
        [FieldAttr(48, false)] public igGuiAnimationTag? _perCharacterAnimation;
        [FieldAttr(56)] public ETypingState _typingState;
        [FieldAttr(60)] public int _currentIndex;
        [FieldAttr(64)] public string? _completeText = null;
        [FieldAttr(72)] public float _leftXCoordinate;
    }
}
