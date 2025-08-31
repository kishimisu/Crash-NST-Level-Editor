namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CFloatSliderNodeData : igObject
    {
        [FieldAttr(16)] public CSlider? _slider;
        [FieldAttr(24)] public igVscDelegateMetaField _reachedStartCallback = new();
        [FieldAttr(40)] public igVscDelegateMetaField _updatingCallback = new();
        [FieldAttr(56)] public igVscDelegateMetaField _reachedEndCallback = new();
        [FieldAttr(72)] public igVscFloatDelegateMetaField _currentValue = new();
        [FieldAttr(88)] public igRawRefMetaField _onUpdate = new();
        [FieldAttr(96)] public igRawRefMetaField _onCompletion = new();
        [FieldAttr(104)] public igRawRefMetaField _onStartReached = new();
        [FieldAttr(112)] public float _startingValue;
        [FieldAttr(116)] public float _endingValue;
        [FieldAttr(120)] public float _duration;
        [FieldAttr(124)] public float _easeInDuration;
        [FieldAttr(128)] public float _easeOutDuration;
        [FieldAttr(132)] public EigEaseType _easeType;
        [FieldAttr(136)] public ESliderMode _mode;
        [FieldAttr(144, false)] public CEntity? _owner;
    }
}
