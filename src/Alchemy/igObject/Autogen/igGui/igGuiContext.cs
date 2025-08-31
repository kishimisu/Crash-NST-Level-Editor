namespace Alchemy
{
    [ObjectAttr(1536, 8)]
    public class igGuiContext : igObject
    {
        [FieldAttr(16)] public igRenderer? _renderer;
        [FieldAttr(24)] public igVfxManager? _vfxManager;
        [FieldAttr(32)] public float _viewerWidthMain;
        [FieldAttr(36)] public float _viewerHeightMain;
        [FieldAttr(40)] public float _settingWidthMain;
        [FieldAttr(44)] public float _settingHeightMain;
        [FieldAttr(48)] public float _screenWidthSub;
        [FieldAttr(52)] public float _screenHeightSub;
        [FieldAttr(56)] public float _expectedScreenWidth;
        [FieldAttr(60)] public float _expectedScreenHeight;
        [FieldAttr(64)] public bool _toolViewerIsRunning;
        [FieldAttr(68)] public float _toolViewerZoomLevel = 1.0f;
        [FieldAttr(72)] public igGuiProjectList? _projects;
        [FieldAttr(80)] public igGuiProjectList? _temporaryProjectsList;
        [FieldAttr(88)] public igGuiProjectList? _updateEnableTemporaryProjectsList;
        [FieldAttr(96)] public igGuiProjectList? _queuedProjects;
        [FieldAttr(104)] public igGuiInput? _input;
        [FieldAttr(112)] public igGuiAnimationCombiner? _animation;
        [FieldAttr(120)] public igGuiVisualizer? _visualizer;
        [FieldAttr(128)] public igGuiEventTouchPressed? _touchPressedEvent;
        [FieldAttr(136)] public igGuiEventTouchReleased? _touchReleasedEvent;
        [FieldAttr(144)] public igGuiEventTouchCanceled? _touchCanceledEvent;
        [FieldAttr(152)] public igGuiEventProjectInputPressed? _projectInputPressedEvent;
        [FieldAttr(160)] public igGuiEventFocusInputPressed? _focusInputPressedEvent;
        [FieldAttr(168)] public igGuiEventProjectInputRepeated? _projectInputRepeatedEvent;
        [FieldAttr(176)] public igGuiEventFocusInputRepeated? _focusInputRepeatedEvent;
        [FieldAttr(184)] public igGuiEventProjectInputReleased? _projectInputReleasedEvent;
        [FieldAttr(192)] public igGuiEventFocusInputReleased? _focusInputReleasedEvent;
        [FieldAttr(200)] public igMutex? _lock;
        [FieldAttr(208)] public bool _disableUpdate;
        [FieldAttr(209)] public bool _disableRender;
        [FieldAttr(210)] public bool _disableControl;
        [FieldAttr(216)] public igHandleMetaField[] _touchFocus = new igHandleMetaField[40];
        [FieldAttr(536)] public igVec2fMetaField[] _initialTouchPosition = new igVec2fMetaField[40];
        [FieldAttr(856)] public igVec2fMetaField[] _lastTouchPosition = new igVec2fMetaField[40];
        [FieldAttr(1176)] public igHandleMetaField[] _hoverFocus = new igHandleMetaField[40];
        [FieldAttr(1496)] public float _forceScreenWidth;
        [FieldAttr(1500)] public float _forceScreenHeight;
        [FieldAttr(1504)] public float _deltaTime;
        [FieldAttr(1512)] public igRawRefMetaField _projectOpenedCallback = new();
        [FieldAttr(1520)] public igRawRefMetaField _projectClosedCallback = new();
        [FieldAttr(1528)] public uint _maxControllers = 8;
    }
}
