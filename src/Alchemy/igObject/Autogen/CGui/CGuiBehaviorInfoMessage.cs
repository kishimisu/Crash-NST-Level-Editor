namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CGuiBehaviorInfoMessage : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiPlaceable? _infoMessageText;
        [FieldAttr(24, false)] public igGuiAnimationTag? _fadeInAnimation;
        [FieldAttr(32)] public CGuiEventInfoMessage.EInfoMessageState _activeInfoState;
        [FieldAttr(40)] public string? _loadingText = null;
        [FieldAttr(48)] public string? _pressToSkip = null;
        [FieldAttr(56)] public string? _tapToSkip = null;
        [FieldAttr(64)] public string? _waitToSkip = null;
        [FieldAttr(72)] public string? _pausedText = null;
        [FieldAttr(80)] public float _infoMessageDelay = 3.0f;
        [FieldAttr(88)] public igVscDelegateMetaField _skipDelegate = new();
    }
}
