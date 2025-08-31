namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class CGuiBehaviorSetPrimaryController : CGuiBehavior
    {
        public enum EState : uint
        {
            eS_DelayingPressStart = 0,
            eS_WaitingForStartPress = 1,
            eS_LoadingSlotsAndOptions = 2,
            eS_NeedSpaceVerification = 3,
            eS_SavingOptionsFile = 4,
            eS_InstallingTrophies = 5,
            eS_LoadingGame = 6,
            eS_DelayingSaveSlots = 7,
            eS_Finished = 8,
        }

        [FieldAttr(144, false)] public igGuiPlaceable? _pressStartPlaceable;
        [FieldAttr(152)] public igHandleMetaField _pressedStartSound = new();
        [FieldAttr(160)] public igHandleMetaField _effectKilledSound = new();
        [FieldAttr(168)] public float _pressStartDelay;
        [FieldAttr(172)] public float _saveSlotsDelay;
        [FieldAttr(176)] public bool _allowOverridePrimaryController;
        [FieldAttr(180)] public int _loadSaveSlot = -1;
        [FieldAttr(184)] public CTimer? _timer;
        [FieldAttr(192)] public EState _state;
        [FieldAttr(200)] public string? _pressStartString = null;
        [FieldAttr(208)] public igHandleMetaField _licenseProject = new();
        [FieldAttr(216)] public igHandleMetaField _iCloudDialog = new();
        [FieldAttr(224)] public EState _farthestState;
    }
}
