namespace Alchemy
{
    [ObjectAttr(264, 8)]
    public class CGuiBehaviorSaveMenu : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _introAnimation;
        [FieldAttr(152, false)] public igGuiAnimationTag? _outroAnimation;
        [FieldAttr(160, false)] public igGuiAnimationTag? _idleAnimation;
        [FieldAttr(168, false)] public igGuiAnimationTag? _preDialogAnimation;
        [FieldAttr(176, false)] public igGuiAnimationTag? _postDialogAnimation;
        [FieldAttr(184)] public EigGuiAnimationLoopMode _animIdleLoopMode = EigGuiAnimationLoopMode.kGuiLoopRepeat;
        [FieldAttr(188)] public bool _alwaysSwitchBackToAutosaveSlot;
        [FieldAttr(192)] public string? _cancelButtonLegendText = null;
        [FieldAttr(200, false)] public igGuiPlaceable? _startingFocusPlaceable;
        [FieldAttr(208, false)] public igGuiProject? _saveDialogBoxProject;
        [FieldAttr(216, false)] public CGuiSaveSlotOperationBase? _currentOperation;
        [FieldAttr(224)] public igHandleMetaField _currentOperationPlaceable = new();
        [FieldAttr(232)] public int _currentSaveSlot;
        [FieldAttr(240)] public igGuiAnimationCategory? _animationCategory;
        [FieldAttr(248)] public CDialogBoxInfo? _pendingDialogBoxInfo;
        [FieldAttr(256)] public bool _pendingOperationConfirmed;
    }
}
