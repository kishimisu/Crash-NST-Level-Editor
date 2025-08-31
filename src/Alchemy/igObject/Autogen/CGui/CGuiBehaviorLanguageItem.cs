namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CGuiBehaviorLanguageItem : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiPlaceable? _languageName;
        [FieldAttr(24)] public EIG_CORE_LANGUAGE _language;
    }
}
