namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class CGuiBehaviorNewGameButton : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _pressAnimation;
        [FieldAttr(152)] public EGuiMenuSound _pressSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(160)] public igHandleMetaField _zoneToBegin = new();
        [FieldAttr(168)] public CFadeOutPresetData? _fadePreset;
        [FieldAttr(176)] public string? _overwriteSaveDialogTitle = null;
        [FieldAttr(184)] public string? _overwriteSaveDialogBody = null;
        [FieldAttr(192)] public string? _confirmOverwriteOptionText = null;
        [FieldAttr(200)] public string? _disableAutoSaveOptionText = null;
        [FieldAttr(208)] public igHandleMetaField _overwriteDialogImage = new();
        [FieldAttr(216, false)] public igGuiProject? _overwriteDialogProject;
        [FieldAttr(224)] public bool _dialogAccepted;
        [FieldAttr(225)] public bool _isSaving;
    }
}
