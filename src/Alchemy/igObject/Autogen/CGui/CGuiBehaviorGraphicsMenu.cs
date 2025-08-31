namespace Alchemy
{
    [ObjectAttr(264, 8)]
    public class CGuiBehaviorGraphicsMenu : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiList? _optionsList;
        [FieldAttr(152, false)] public igGuiPlaceable? _settingInfoText;
        [FieldAttr(160, false)] public igGuiPlaceable? _gpuInfoText;
        [FieldAttr(168, false)] public igGuiAnimationTag? _crash1Animation;
        [FieldAttr(176, false)] public igGuiAnimationTag? _crash2Animation;
        [FieldAttr(184, false)] public igGuiAnimationTag? _crash3Animation;
        [FieldAttr(192)] public string? _option1Text = null;
        [FieldAttr(200)] public string? _option2Text = null;
        [FieldAttr(208)] public string? _backText = null;
        [FieldAttr(216)] public int _displayRevertTimeoutSeconds = 10;
        [FieldAttr(224)] public string? _countdownPlaceableName = "Countdown";
        [FieldAttr(232)] public bool _isClosing;
        [FieldAttr(233)] public bool _showApplyButton;
        [FieldAttr(234)] public bool _displayRevertRequested;
        [FieldAttr(240)] public igHandleMetaField _displayRevertDialogProject = new();
        [FieldAttr(248)] public igTimeMetaField _displayRevertDialogStartTime = new();
        [FieldAttr(256, false)] public CGuiBehaviorBaseGraphicsMenuOption? currentFocusedBehavior;
    }
}
