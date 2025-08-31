namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CCutsceneActionOpenUi : CCutsceneAction
    {
        [FieldAttr(24)] public string? _menuName = null;
        [FieldAttr(32)] public CCharacterIntroductionInfo? _characterIntroductionInfo;
    }
}
