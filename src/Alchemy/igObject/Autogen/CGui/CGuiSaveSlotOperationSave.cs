namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CGuiSaveSlotOperationSave : CGuiSaveSlotOperationBase
    {
        [FieldAttr(72)] public string? _overwriteSaveDialogTitle = null;
        [FieldAttr(80)] public string? _overwriteSaveDialogBody = null;
        [FieldAttr(88)] public string? _confirmOverwriteOptionText = null;
        [FieldAttr(96)] public string? _cancelOverwriteOptionText = null;
        [FieldAttr(104)] public igHandleMetaField _overwriteDialogImage = new();
    }
}
