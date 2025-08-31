namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CGuiActionTogglePause : igGuiAction
    {
        [FieldAttr(48)] public bool _pause;
        [FieldAttr(52)] public ESoundPauseType _soundPauseType = ESoundPauseType.eSPT_PauseMenu;
    }
}
