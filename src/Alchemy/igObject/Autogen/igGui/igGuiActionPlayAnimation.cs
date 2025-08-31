namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class igGuiActionPlayAnimation : igGuiAction
    {
        [FieldAttr(48, false)] public igGuiAnimationTag? _animation;
        [FieldAttr(56, false)] public igGuiPlaceable? _placeable;
        [FieldAttr(64)] public igTimeMetaField _startTime = new();
        [FieldAttr(68)] public float _speed = 1.0f;
        [FieldAttr(72)] public bool _reverse;
        [FieldAttr(76)] public EigGuiAnimationLoopMode _loopMode;
        [FieldAttr(80)] public bool _manualTimeControl;
        [FieldAttr(88)] public igGuiAnimationCategory? _category;
        [FieldAttr(96)] public bool _disableControls;
        [FieldAttr(97)] public bool _onTree = true;
        [FieldAttr(98)] public bool _onRoot;
        [FieldAttr(100)] public float _animationLength;
        [FieldAttr(104, false)] public igGuiPlaceable? _signalObject;
    }
}
