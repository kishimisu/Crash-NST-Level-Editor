namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CGuiCrashSaveSlotOperationLoad : CGuiSaveSlotOperationLoad
    {
        [FieldAttr(128)] public igHandleMetaField _crash1OnLoadedLevel = new();
        [FieldAttr(136)] public igHandleMetaField _crash2OnLoadedLevel = new();
        [FieldAttr(144)] public igHandleMetaField _crash3OnLoadedLevel = new();
    }
}
