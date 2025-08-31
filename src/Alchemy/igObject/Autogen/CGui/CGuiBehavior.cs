namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CGuiBehavior : igGuiBehavior
    {
        public enum ETouchHandlingMode : uint
        {
            eTHM_None = 0,
            eTHM_Focus = 1,
            eTHM_FocusThenSelect = 2,
            eTHM_FocusAndSelect = 3,
        }

        public enum ENetworkSyncWaitMode : uint
        {
            eNSWM_None = 0,
            eNSWM_SyncWait = 1,
            eNSWM_SyncWaitForUi = 2,
        }

        public enum ETouchStatus : uint
        {
            eTS_TouchedWithoutFocus = 0,
            eTS_TouchedWithFocus = 1,
            eTS_Idle = 2,
        }

        [FieldAttr(16)] public CGuiBaseSoundContainer? _soundContainer;
        [FieldAttr(24)] public CGuiButtonLegendTable? _defaultButtonLegendData;
        [FieldAttr(32)] public ETouchHandlingMode _touchHandlingMode = CGuiBehavior.ETouchHandlingMode.eTHM_FocusThenSelect;
        [FieldAttr(36)] public igVec2fMetaField _touchPadding = new();
        [FieldAttr(48, false)] public igGuiPlaceable? _touchFocusPlaceable;
        [FieldAttr(56)] public bool _shoudFocusOnHover;
        [FieldAttr(57)] public bool _logEvents;
        [FieldAttr(64)] public string? _networkEventName = null;
        [FieldAttr(72)] public ENetworkSyncWaitMode _networkSyncWait;
        [FieldAttr(76)] public bool _usesNetworkFeatures;
        [FieldAttr(80)] public uint _overrideRenderingMode;
        [FieldAttr(88)] public CTimer? _activeTimer;
        [FieldAttr(96, false)] public igGuiPlaceable? _place;
        [FieldAttr(104)] public CEGuiMenuSoundList? _soundsPlayed;
        [FieldAttr(112)] public ETouchStatus _touchStatus = CGuiBehavior.ETouchStatus.eTS_Idle;
        [FieldAttr(116)] public igVec2fMetaField _touchPosition = new();
        [FieldAttr(124)] public igGuiInput.EController _touchControl;
        [FieldAttr(128)] public CChangeRequest? _syncWaitRequest;
        [FieldAttr(136)] public igGuiInput.ESignal _touchSignal = igGuiInput.ESignal.kSignalButtonSelect;
        [FieldAttr(140)] public bool _updatedOnce;
    }
}
