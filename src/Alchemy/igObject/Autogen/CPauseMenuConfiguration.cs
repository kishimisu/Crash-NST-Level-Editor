namespace Alchemy
{
    [ObjectAttr(112, 16)]
    public class CPauseMenuConfiguration : igObject
    {
        [ObjectAttr(4)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _useCarousel;
            [FieldAttr(1, size: 1)] public bool _fullscreenInOnOpen;
            [FieldAttr(2, size: 1)] public bool _showAreaName;
            [FieldAttr(3, size: 1)] public bool _showCharacterBarWidget;
            [FieldAttr(4, size: 1)] public bool _showVaultCodeWidget;
            [FieldAttr(5, size: 1)] public bool _showDescriptions = false;
            [FieldAttr(6, size: 1)] public bool _showObjectives;
            [FieldAttr(7, size: 1)] public bool _showDetailsImage;
            [FieldAttr(8, size: 1)] public bool _allowBackOutOnButtonPress = false;
            [FieldAttr(9, size: 1)] public bool _pauseGame;
            [FieldAttr(10, size: 1)] public bool _showPlayerActorInScreenspace;
            [FieldAttr(11, size: 1)] public bool _showBackgroundFilmStrip;
            [FieldAttr(12, size: 1)] public bool _playTutorialVo;
            [FieldAttr(13, size: 1)] public bool _logEvents;
        }

        [FieldAttr(16)] public string? _displayName = null;
        [FieldAttr(24)] public CPauseMenuOptionList? _menuOptions;
        [FieldAttr(32)] public CPauseMenuOption? _menuOptionOnOption2;
        [FieldAttr(40)] public igHandleMetaField _templateItem = new();
        [FieldAttr(48)] public igVec4fMetaField _marginOffset = new();
        [FieldAttr(64)] public igObject? _gameData;
        [FieldAttr(72)] public igHandleMetaField _initiallyFocusedOption = new();
        [FieldAttr(80)] public igHandleMetaField _initiallyFocusedOptionOverride = new();
        [FieldAttr(88)] public string? _additionalGuiWidget = null;
        [FieldAttr(96)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(104)] public string? _networkEventName = null;
    }
}
