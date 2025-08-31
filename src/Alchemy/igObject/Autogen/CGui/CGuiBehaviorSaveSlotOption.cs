namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class CGuiBehaviorSaveSlotOption : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _pressAnimation;
        [FieldAttr(152, false)] public igGuiAnimationTag? _onLoadAnimation;
        [FieldAttr(160)] public EGuiMenuSound _pressSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(164)] public int _saveSlot;
        [FieldAttr(168)] public CGuiSaveSlotOperationList? _saveOperations;
        [FieldAttr(176, false)] public CGuiSaveSlotOperationBase? _currentOperation;
    }
}
