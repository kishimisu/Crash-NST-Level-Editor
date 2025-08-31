namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class COpenKeyboardParams : igObject
    {
        [FieldAttr(16)] public EPlayerId _playerId;
        [FieldAttr(20)] public uint _maxTextLength;
        [FieldAttr(24)] public igVec2fMetaField _position = new();
        [FieldAttr(32)] public string? _placeholderText = null;
        [FieldAttr(40)] public string? _titleText = null;
        [FieldAttr(48)] public igLanguageList? _allowedLanguages;
    }
}
