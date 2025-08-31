namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class igGuiAnimationPlayState : igObject
    {
        [FieldAttr(16)] public igGuiAnimation? _animation;
        [FieldAttr(24)] public igGuiAnimationBinding? _binding;
        [FieldAttr(32, false)] public igGuiPlaceable? _signalObject;
        [FieldAttr(40)] public int _signalCount;
        [FieldAttr(48, false)] public igGuiAction? _action;
        [FieldAttr(56)] public int _actionCount;
        [FieldAttr(60)] public bool _manualTimeControl;
        [FieldAttr(64)] public float _velocity;
        [FieldAttr(68)] public EigGuiAnimationLoopMode _loopMode;
        [FieldAttr(72)] public igGuiAnimationCategory? _category;
        [FieldAttr(80)] public igGuiProject? _project;
        [FieldAttr(88)] public bool _disableControls;
        [FieldAttr(92)] public igTimeMetaField _time = new();
        [FieldAttr(96)] public igTimeMetaField _previousTime = new();
        [FieldAttr(100)] public bool _signalOnce;
        [FieldAttr(101)] public bool _deinitialized = true;
        [FieldAttr(104)] public igVscDelegateMetaField _finishedCallback = new();
    }
}
