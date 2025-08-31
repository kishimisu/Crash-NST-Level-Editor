namespace Alchemy
{
    [ObjectAttr(240, 8)]
    public class CGuiBehaviorPauseMenuOptionRestart : CGuiBehaviorPauseMenuOption
    {
        [FieldAttr(200)] public string? _restartString = "Restart";
        [FieldAttr(208)] public string? _cancelString = "Cancel";
        [FieldAttr(216)] public string? _restartDialogBodyString = "Restart the map? All unsaved progress will be lost.";
        [FieldAttr(224)] public string? _restartDialogSaveDisabledBodyString = "Restart the map? All progress will be lost.";
        [FieldAttr(232)] public bool _skipConfirmation;
    }
}
