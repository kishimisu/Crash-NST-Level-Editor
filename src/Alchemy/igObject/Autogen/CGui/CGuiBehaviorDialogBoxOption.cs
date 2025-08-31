namespace Alchemy
{
    [ObjectAttr(176, 8)]
    public class CGuiBehaviorDialogBoxOption : CGuiBehavior
    {
        public enum EGuiDialogBoxOption : uint
        {
            eGDBO_OptionNone = 0,
            eGDBO_Option1 = 1,
            eGDBO_Option2 = 2,
        }

        [FieldAttr(144)] public EGuiDialogBoxOption _option;
        [FieldAttr(152, false)] public igGuiPlaceable? _text;
        [FieldAttr(160)] public CDialogBoxInfo? _dialogBoxInfo;
        [FieldAttr(168)] public CScopedScheduledFunctionList? _scheduledTelegrams;
    }
}
