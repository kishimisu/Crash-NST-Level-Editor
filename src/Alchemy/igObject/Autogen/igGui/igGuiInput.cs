namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class igGuiInput : igObject
    {
        public enum EController : uint
        {
            kControllerNone = 0,
            kController1 = 1,
            kController2 = 2,
            kController3 = 4,
            kController4 = 8,
            kController5 = 16,
            kController6 = 32,
            kController7 = 64,
            kController8 = 128,
            kControllerAll = 255,
            // kControllerMax = 8,
        }

        public enum ESignal : uint
        {
            kSignalButtonUp = 0,
            kSignalButtonDown = 1,
            kSignalButtonLeft = 2,
            kSignalButtonRight = 3,
            kSignalButtonDpadUp = 4,
            kSignalButtonDpadDown = 5,
            kSignalButtonDpadLeft = 6,
            kSignalButtonDpadRight = 7,
            kSignalButtonSelect = 8,
            kSignalButtonBack = 9,
            kSignalButtonOption1 = 10,
            kSignalButtonOption2 = 11,
            kSignalButtonMenu = 12,
            kSignalButtonPause = 13,
            kSignalTriggerRight = 14,
            kSignalTriggerLeft = 15,
            kSignalBumperRight = 16,
            kSignalBumperLeft = 17,
            kSignalTouched1 = 18,
            kSignalTouched2 = 19,
            kSignalTouched3 = 20,
            kSignalTouched4 = 21,
            kSignalTouched5 = 22,
            kSignalGestured1 = 23,
            kSignalButtonOption3 = 24,
            kSignalButtonTabLeft = 25,
            kSignalButtonTabRight = 26,
            kSignalMax = 27,
        }

        [FieldAttr(16)] public uint[] _currentPressState = new uint[8];
        [FieldAttr(48)] public uint[] _lastPressState = new uint[8];
        [FieldAttr(80)] public uint[] _repeatedState = new uint[8];
        [FieldAttr(112)] public igFloatListList? _repeatTimers;
        [FieldAttr(120)] public float _debounceTime = 0.33333299f;
        [FieldAttr(124)] public float _repeatTime = 0.166666f;
        [FieldAttr(128, false)] public igGuiContext? _context;
    }
}
