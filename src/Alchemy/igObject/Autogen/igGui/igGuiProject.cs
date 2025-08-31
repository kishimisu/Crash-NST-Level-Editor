namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class igGuiProject : igObject
    {
        [ObjectAttr(1)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _canHaveFocus = true;
            [FieldAttr(1, size: 1)] public bool _renderWhenDisabled;
            [FieldAttr(2, size: 1)] public bool _updateWhenDisabled;
            [FieldAttr(3, size: 1)] public bool _onSubScreen;
            [FieldAttr(4, size: 1)] public bool _deactivated;
            [FieldAttr(5, size: 1)] public bool _isEnabled;
            [FieldAttr(6, size: 1)] public bool _allowTouchInput;
        }

        [FieldAttr(16)] public igGuiPlaceable? _rootPlaceable;
        [FieldAttr(24)] public igGuiAssetList? _assets;
        [FieldAttr(32)] public int _priority;
        [FieldAttr(36)] public int _disableUnder;
        [FieldAttr(40)] public uint _updateFrequency = 1;
        [FieldAttr(44)] public uint _frameCount;
        [FieldAttr(48)] public float _timeSinceLastUpdate;
        [FieldAttr(52)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(56)] public igUpdater? _updater;
        [FieldAttr(64)] public igGuiProjectParameters.EQueueType _queueBehavior;
        [FieldAttr(68)] public igGuiInput.EController _control;
        [FieldAttr(72)] public int _controlDisableCount;
        [FieldAttr(80)] public igObject[] _focusPlaceable = new igObject[8];
        [FieldAttr(144, false)] public igGuiContext? _context;
        [FieldAttr(152, false)] public igGuiProject? _sourceProject;
        [FieldAttr(160)] public igGuiInstanceMap? _instanceMap;
        [FieldAttr(168)] public igObject? _gameData;
        [FieldAttr(176)] public igVectorMetaField<igGuiAction> _activeActions = new();
        [FieldAttr(200)] public float _authoredScreenWidth;
        [FieldAttr(204)] public float _authoredScreenHeight;
        [FieldAttr(208)] public igVectorMetaField<igGuiPlaceable> _runtimePlaceables = new();
    }
}
