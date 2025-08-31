namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CCutsceneData : igObject
    {
        [FieldAttr(16)] public string? _cutsceneName = null;
        [FieldAttr(24)] public bool _skipEnabled = true;
        [FieldAttr(25)] public bool _lockControls = true;
        [FieldAttr(26)] public bool _invulnerable = true;
        [FieldAttr(27)] public bool _targetable;
        [FieldAttr(28)] public bool _hudEnabled;
        [FieldAttr(29)] public bool _showCollectibles;
        [FieldAttr(30)] public bool _showInteractionVfx = true;
        [FieldAttr(31)] public bool _disableEntitiesWithComponent = true;
        [FieldAttr(32)] public bool _useCameraForAuxiliaryVisibilityArea = true;
        [FieldAttr(33)] public bool _hidePlayers;
        [FieldAttr(34)] public bool _mutePlayers;
        [FieldAttr(35)] public bool _pauseOnEnd;
        [FieldAttr(36)] public bool _cameraIsSoundFocus = true;
        [FieldAttr(37)] public bool _isSplitscreenAllowed = true;
        [FieldAttr(40)] public int _framesToSkipRendering;
        [FieldAttr(44)] public ESoundFocusPositionType _cameraSoundFocusPreCutsceneType;
    }
}
