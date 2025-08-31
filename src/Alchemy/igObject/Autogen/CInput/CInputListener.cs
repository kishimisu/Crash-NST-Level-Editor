namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class CInputListener : igObject
    {
        public enum EInputState : uint
        {
            kUnknown = 0,
            kPressed = 1,
            kHolding = 2,
            kReleased = 3,
        }

        [ObjectAttr(2)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _stopped;
            [FieldAttr(1, size: 1)] public bool _stopOnPressed;
            [FieldAttr(2, size: 1)] public bool _stopOnHold;
            [FieldAttr(3, size: 1)] public bool _stopOnReleased;
        }

        [FieldAttr(16)] public EXBUTTON _button;
        [FieldAttr(20)] public Flags _flags = new();
        [FieldAttr(24)] public EPlayerId _player = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(32)] public igVscFloatDelegateMetaField _deflectionDataOut = new();
        [FieldAttr(48)] public igVscVec2fDelegateMetaField _stickDeflectionDataOut = new();
        [FieldAttr(64)] public igVscVec3fDelegateMetaField _relativeStickDeflectionDataOut = new();
        [FieldAttr(80)] public igVscDelegateMetaField _pressedCallback = new();
        [FieldAttr(96)] public igVscDelegateMetaField _holdingCallback = new();
        [FieldAttr(112)] public igVscDelegateMetaField _releasedCallback = new();
        [FieldAttr(128)] public EInputState _state;
    }
}
