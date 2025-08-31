namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igGuiActionOpenProject : igGuiAction
    {
        [FieldAttr(48)] public igHandleMetaField _project = new();
        [FieldAttr(56)] public int _projectPriority;
        [FieldAttr(60)] public igGuiProjectParameters.EQueueType _queueBehavior;
        [FieldAttr(64)] public int _disableUnder;
        [FieldAttr(68)] public igGuiInput.EController _control = igGuiInput.EController.kController1 | igGuiInput.EController.kController2 | igGuiInput.EController.kController3 | igGuiInput.EController.kController4 | igGuiInput.EController.kController5 | igGuiInput.EController.kController6 | igGuiInput.EController.kController7 | igGuiInput.EController.kController8;
        [FieldAttr(72)] public igObject? _gameData;
    }
}
