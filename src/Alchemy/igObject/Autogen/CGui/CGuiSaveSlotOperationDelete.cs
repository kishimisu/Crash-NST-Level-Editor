namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CGuiSaveSlotOperationDelete : CGuiSaveSlotOperationBase
    {
        [FieldAttr(72)] public string? _deleteSaveDialogTitle = null;
        [FieldAttr(80)] public string? _deleteSaveDialogBody = null;
        [FieldAttr(88)] public string? _confirmDeleteOptionText = null;
        [FieldAttr(96)] public string? _cancelDeleteOptionText = null;
        [FieldAttr(104)] public igHandleMetaField _deleteDialogImage = new();
    }
}
