namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CGuiListItemPopulatorPauseMenu : igGuiListItemPopulator
    {
        [FieldAttr(16)] public bool _isCarousel;
        [FieldAttr(17)] public bool _refreshMenuOptions = true;
        [FieldAttr(24, false)] public CPauseMenuOptionList? _sourceMenuOptions;
        [FieldAttr(32)] public CPauseMenuOptionList? _pauseMenuOptions;
    }
}
