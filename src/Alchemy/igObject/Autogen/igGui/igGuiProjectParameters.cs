namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGuiProjectParameters : igObject
    {
        public enum EQueueType : uint
        {
            kQueueNone = 0,
            kQueueRegular = 1,
            kQueueOne = 2,
        }

        [FieldAttr(16)] public igGuiInput.EController _inputControl = igGuiInput.EController.kController1 | igGuiInput.EController.kController2 | igGuiInput.EController.kController3 | igGuiInput.EController.kController4 | igGuiInput.EController.kController5 | igGuiInput.EController.kController6 | igGuiInput.EController.kController7 | igGuiInput.EController.kController8;
        [FieldAttr(20)] public int _priority;
        [FieldAttr(24)] public int _disableUnder;
        [FieldAttr(28)] public EQueueType _queueBehavior;
        [FieldAttr(32)] public bool _onSubScreen;
        [FieldAttr(40, false)] public igObject? _gameData;
    }
}
