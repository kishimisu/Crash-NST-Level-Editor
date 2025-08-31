namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CGuiBehaviorTimer : igGuiBehavior
    {
        [FieldAttr(16)] public CGuiTimerData? _timerData;
        [FieldAttr(24)] public CGuiScriptTimerData? _scriptTimerData;
        [FieldAttr(32)] public bool _sentCloseEvent;
        [FieldAttr(33)] public bool _startedLowTimeAnimation;
        [FieldAttr(34)] public bool _isClosing;
        [FieldAttr(35)] public bool _switchedToUrgentSound;
        [FieldAttr(40)] public igHandleMetaField _playingSound = new();
        [FieldAttr(48)] public float _lowTimeAnimationStartTime = 10.0f;
        [FieldAttr(56, false)] public igGuiPlaceable? _timeRemainingText;
        [FieldAttr(64, false)] public igGuiAnimationTag? _addTimeAnimation;
        [FieldAttr(72)] public igGuiAnimationCategory? _addTimeAnimationCategory;
        [FieldAttr(80, false)] public igGuiAnimationTag? _lowTimeAnimation;
        [FieldAttr(88)] public igGuiAnimationCategory? _lowTimeAnimationCategory;
        [FieldAttr(96, false)] public igGuiPlaceable? _fadeOutPlaceable;
        [FieldAttr(104, false)] public igGuiAnimationTag? _fadeOutAnimation;
        [FieldAttr(112)] public igGuiAnimationCategory? _fadeOutAnimationCategory;
        [FieldAttr(120, false)] public igGuiPlaceable? _starPlaceable;
        [FieldAttr(128)] public igHandleMetaField _loopingTickSound = new();
        [FieldAttr(136)] public bool _loopingTickSoundFadeOut;
        [FieldAttr(144)] public igHandleMetaField _loopingUrgentTickSound = new();
        [FieldAttr(152)] public bool _loopingUrgentTickSoundFadeOut;
        [FieldAttr(156)] public float _urgentSoundTimeRemainingPercentage = 30.0f;
    }
}
