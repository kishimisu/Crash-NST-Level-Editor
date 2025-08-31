namespace Alchemy
{
    [ObjectAttr(680, 8)]
    public class CGuiSystemData : igObject
    {
        [FieldAttr(16)] public CStringPauseMenuConfigurationHashTable? _pauseConfigurations;
        [FieldAttr(24)] public igStringRefList? _streamedGuiProjectList;
        [FieldAttr(32)] public igStringRefListList? _streamedGuiProjectGroups;
        [FieldAttr(40)] public CControllerTypeToGuiInputSignalIconMaterialTable? _controllerTypeToGuiInputSignalIconTable;
        [FieldAttr(48)] public CGuiMenuSoundTable? _globalGuiSoundData;
        [FieldAttr(56)] public CGuiButtonLegendTable? _globalButtonLegendOptions;
        [FieldAttr(64)] public CXButtonStringTable? _globalButtonCharacters;
        [FieldAttr(72)] public CXButtonStringTable? _kbVirtualButtonCharacters;
        [FieldAttr(80)] public CControllerButtonCharacterMapList? _controllerSpecificMaps;
        [FieldAttr(88)] public CControllerButtonCharacterMapList? _controllerVehicleSpecificMaps;
        [FieldAttr(96)] public CGuiButtonLegendButtonList? _buttonLegendOrder;
        [FieldAttr(104)] public igVec2fMetaField _defaultLegendPosition = new();
        [FieldAttr(112)] public igVec2fMetaField _defaultVerticalLegendPosition = new();
        [FieldAttr(120)] public igVec2fMetaField _defaultTabletVerticalLegendPosition = new();
        [FieldAttr(128)] public int _numSpacesBetweenOptions = 4;
        [FieldAttr(136)] public CGuiKeyboardMenuList? _keyboardMenuOrder;
        [FieldAttr(144)] public CGuiKeyMappingTable? _keyboardMenuMappingTable;
        [FieldAttr(152)] public CGuiGraphicsMenuSettingTable? _graphicsMenuTable;
        [FieldAttr(160)] public CGuiGraphicsMenuSettingTable? _graphicsMenuDetails;
        [FieldAttr(168)] public float _smallDeviceUIScaleFactor = 1.29999995f;
        [FieldAttr(176)] public CGuiMaterialHandleList? _questRankMaterials;
        [FieldAttr(184)] public CGuiMaterialHandleList? _giantsQuestRankMaterials;
        [FieldAttr(192)] public igVec2fList? _damageNumberOffsets;
        [FieldAttr(200)] public float _damageNumberCooldown = 0.5f;
        [FieldAttr(204)] public float _tutorialBroadcastRadius = 600.0f;
        [FieldAttr(208)] public string? _titleMenuLevelName = "ui/mainmenubackground/mainmenubackground";
        [FieldAttr(216)] public string? _loadingMenuName = "PVP_2017_Loading";
        [FieldAttr(224)] public string? _startScreenMenuName = "StartScreen_2015";
        [FieldAttr(232)] public string? _resultsScreenMenuName = null;
        [FieldAttr(240)] public float _autoSaveLoopTime = 0.5f;
        [FieldAttr(244)] public igVfxRangedCurveMetaField _autoSaveXPositionCurve = new();
        [FieldAttr(328)] public igVfxRangedCurveMetaField _autoSaveYPositionCurve = new();
        [FieldAttr(412)] public igVfxRangedCurveMetaField _autoSaveRotationCurve = new();
        [FieldAttr(496)] public igVfxRangedCurveMetaField _autoSaveXScaleCurve = new();
        [FieldAttr(580)] public igVfxRangedCurveMetaField _autoSaveYScaleCurve = new();
        [FieldAttr(664)] public igVec2fMetaField _autoSaveIconDimensions = new();
        [FieldAttr(672)] public igStringRefList? _validTimeTrialInitialsCharacters;
    }
}
