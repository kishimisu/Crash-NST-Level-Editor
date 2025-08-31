namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CGuiListItemPopulatorLanguages : igGuiListItemPopulator
    {
        [FieldAttr(16)] public igLanguageList? _languages;
        [FieldAttr(24)] public string? _english = null;
        [FieldAttr(32)] public string? _french = null;
        [FieldAttr(40)] public string? _italian = null;
        [FieldAttr(48)] public string? _german = null;
        [FieldAttr(56)] public string? _spanish = null;
        [FieldAttr(64)] public string? _dutch = null;
        [FieldAttr(72)] public string? _danish = null;
        [FieldAttr(80)] public string? _swedish = null;
        [FieldAttr(88)] public string? _finnish = null;
        [FieldAttr(96)] public string? _norwegian = null;
        [FieldAttr(104)] public string? _japanese = null;
    }
}
