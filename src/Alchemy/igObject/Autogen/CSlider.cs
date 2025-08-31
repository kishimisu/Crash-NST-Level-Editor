namespace Alchemy
{
    [ObjectAttr(136, 8, metaObject: true)]
    public class CSlider : Object
    {
        public enum EState : uint
        {
            eSTT_Standby = 0,
            eSTT_Active = 1,
            eSTT_Done = 2,
        }

        [ObjectAttr(4)]
        public class FlagsBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public CSlider.EState _currentState;
            [FieldAttr(3, size: 1)] public bool _isPaused;
            [FieldAttr(4, size: 1)] public bool _isScriptObject;
        }

        [FieldAttr(32)] public float _startingValue;
        [FieldAttr(36)] public float _endingValue;
        [FieldAttr(40)] public float _totalDuration;
        [FieldAttr(44)] public float _easeInDuration;
        [FieldAttr(48)] public float _easeOutDuration;
        [FieldAttr(52)] public EigEaseType _easeType = EigEaseType.kEaseTypeQuadratic;
        [FieldAttr(56)] public ESliderMode _mode;
        [FieldAttr(60)] public FlagsBitfield _flagsBitfield = new();
        [FieldAttr(64)] public bool _reversed;
        [FieldAttr(65)] public bool _networkReversed;
        [FieldAttr(68)] public float _value;
        [FieldAttr(72)] public float _timeElapsed;
        [FieldAttr(76)] public bool _replicated = true;
        [FieldAttr(80)] public u64 _sliderNodeID;
        [FieldAttr(88)] public float _netTimeElapsedTolerance = 0.1f;
        [FieldAttr(96)] public igHandleMetaField _entity = new();
        [FieldAttr(104)] public igHandleMetaField _callbackOwner = new();
        [FieldAttr(112)] public igRawRefMetaField _onUpdate = new();
        [FieldAttr(120)] public igRawRefMetaField _onCompletion = new();
        [FieldAttr(128)] public igRawRefMetaField _onStartReached = new();
    }
}
