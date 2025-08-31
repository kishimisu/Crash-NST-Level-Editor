namespace Alchemy
{
    [ObjectAttr(112, 8, metaObject: true)]
    public class CUIDialogBoxOption : Object
    {
        [FieldAttr(32)] public string? _text = "";
        [FieldAttr(40)] public igRawRefMetaField _codeCallback = new();
        [FieldAttr(48)] public igRawRefMetaField _callbackUserData = new();
        [FieldAttr(56)] public CEntityMessage? _optionSelectedMessage;
        [FieldAttr(64)] public CEntityHandleList? _optionSelectedMessageRecipients;
        [FieldAttr(72)] public CTelegramList? _optionSelectedTelegrams;
        [FieldAttr(80)] public CScopedScheduledFunctionList? _scheduledTelegrams;
        [FieldAttr(88)] public igHandleMetaField _selectionSound = new();
        [FieldAttr(96)] public igVscDelegateMetaField _delegateCallback = new();
    }
}
