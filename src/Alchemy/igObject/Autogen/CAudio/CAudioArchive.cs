namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CAudioArchive : igObject
    {
        [FieldAttr(16)] public string? _name = "NOT_SET";
        [FieldAttr(24)] public CSoundList? _soundList;
        [FieldAttr(32)] public CPlatformAudioSettingsOverrideList? _settingsOverrideList;
        [FieldAttr(40)] public bool _isStreamed;
        [FieldAttr(41)] public bool _isGenerated;
        [FieldAttr(42)] public bool _isLocalized;
        [FieldAttr(43)] public bool _default;
        [FieldAttr(44)] public bool _isCollisionBank;
        [FieldAttr(45)] public bool _loaded;
        [FieldAttr(46)] public bool _sorted;
        [FieldAttr(47)] public bool _mute;
        [FieldAttr(48)] public bool _solo;
    }
}
