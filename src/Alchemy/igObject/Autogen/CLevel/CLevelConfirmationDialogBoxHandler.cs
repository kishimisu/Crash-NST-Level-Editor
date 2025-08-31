namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CLevelConfirmationDialogBoxHandler : igObject
    {
        public enum EContextualParameter : uint
        {
            eCP_None = 0,
            eCP_QuestTitle = 1,
            eCP_ObjectiveDescription = 2,
            eCP_LevelName = 3,
            eCP_ChapterName = 4,
        }

        [FieldAttr(16)] public EContextualParameter _title;
        [FieldAttr(24)] public string? _bodyString = null;
        [FieldAttr(32)] public EContextualParameter _bodyParameter0;
        [FieldAttr(36)] public EContextualParameter _bodyParameter1;
        [FieldAttr(40)] public EContextualParameter _bodyParameter2;
        [FieldAttr(48)] public igHandleMetaField _level = new();
        [FieldAttr(56)] public igHandleMetaField _checkpoint = new();
        [FieldAttr(64)] public string? _questTitle = null;
        [FieldAttr(72)] public string? _objectiveDescription = null;
        [FieldAttr(80)] public CChangeRequest? _syncWaitRequest;
    }
}
