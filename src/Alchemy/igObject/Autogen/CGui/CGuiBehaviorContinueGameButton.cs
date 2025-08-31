namespace Alchemy
{
    [ObjectAttr(248, 8)]
    public class CGuiBehaviorContinueGameButton : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _pressAnimation;
        [FieldAttr(152)] public EGuiMenuSound _pressSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(160)] public igHandleMetaField _zoneToBegin = new();
        [FieldAttr(168)] public CFadeOutPresetData? _fadePreset;
        [FieldAttr(176, false)] public igGuiPlaceable? _backupPlaceable;
        [FieldAttr(184)] public string? _defaultText = "CONTINUE";
        [FieldAttr(192)] public string? _deletingText = "...DELETING...";
        [FieldAttr(200)] public CDialogBoxInfo? _corruptSaveDialog;
        [FieldAttr(208)] public CDialogBoxInfo? _invalidOwnerSaveDialog;
        [FieldAttr(216)] public CDialogBoxInfo? _deleteConfirmedDialog;
        [FieldAttr(224)] public CDialogBoxInfo? _insufficientSpaceForAutosaveDialog;
        [FieldAttr(232, false)] public igGuiProject? _dialogProject;
        [FieldAttr(240)] public bool _dialogAccepted;
        [FieldAttr(244)] public ESaveLoad _pendingSaveProcess;
    }
}
