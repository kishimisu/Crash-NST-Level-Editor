namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CGuiSaveSlotOperationLoad : CGuiSaveSlotOperationBase
    {
        [FieldAttr(72)] public igHandleMetaField _onLoadedLevel = new();
        [FieldAttr(80)] public CFadeOutPresetData? _fadePreset;
        [FieldAttr(88)] public string? _loadSaveDialogTitle = null;
        [FieldAttr(96)] public string? _loadSaveDialogBody = null;
        [FieldAttr(104)] public string? _confirmLoadOptionText = null;
        [FieldAttr(112)] public string? _cancelLoadOptionText = null;
        [FieldAttr(120)] public igHandleMetaField _loadDialogImage = new();
    }
}
