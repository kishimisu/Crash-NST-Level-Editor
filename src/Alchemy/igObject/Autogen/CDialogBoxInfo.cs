namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class CDialogBoxInfo : igObject
    {
        [FieldAttr(16)] public CUIDialogBoxOption? _option1;
        [FieldAttr(24)] public CUIDialogBoxOption? _option2;
        [FieldAttr(32)] public CGuiBehaviorDialogBoxOption.EGuiDialogBoxOption _optionToFocus = CGuiBehaviorDialogBoxOption.EGuiDialogBoxOption.eGDBO_Option2;
        [FieldAttr(40)] public string? _title = "";
        [FieldAttr(48)] public string? _body = "";
        [FieldAttr(56)] public string? _closeDialogLegendText = "";
        [FieldAttr(64)] public bool _canAccept = true;
        [FieldAttr(65)] public bool _canCancel = true;
        [FieldAttr(72)] public igRawRefMetaField _updateCallback = new();
        [FieldAttr(80)] public igRawRefMetaField _cancelCallback = new();
        [FieldAttr(88)] public igRawRefMetaField _closeCallback = new();
        [FieldAttr(96)] public igRawRefMetaField _inputCallback = new();
        [FieldAttr(104)] public igRawRefMetaField _callbackUserData = new();
        [FieldAttr(112)] public CEntityMessage? _onCloseMessage;
        [FieldAttr(120)] public CEntityHandleList? _onCloseMessageRecipients;
        [FieldAttr(128)] public CTelegramList? _backOutTelegrams;
        [FieldAttr(136)] public igHandleMetaField component = new();
        [FieldAttr(144)] public bool _forcePause;
        [FieldAttr(148)] public float _delayInputDuration;
        [FieldAttr(152)] public igHandleMetaField _image = new();
        [FieldAttr(160)] public EeDialogCloseSource _closeSource = EeDialogCloseSource.eDCS_CloseAllUI;
        [FieldAttr(168)] public igVscDelegateMetaField _cancelDelegateCallback = new();
    }
}
