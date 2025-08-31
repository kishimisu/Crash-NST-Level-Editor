namespace Alchemy
{
    [ObjectAttr(432, 16)]
    public class CCameraBox : CCameraBase
    {
        public enum ECameraBoxSide : uint
        {
            eCBS_Front = 0,
            eCBS_Back = 1,
            eCBS_Right = 2,
            eCBS_Left = 3,
            eCBS_Bottom = 4,
            eCBS_Top = 5,
            eCBS_None = 6,
            eCBS_Debug = 7,
        }

        [FieldAttr(288)] public igVec3fMetaField _min = new();
        [FieldAttr(300)] public igVec3fMetaField _max = new();
        [FieldAttr(312)] public igHandleMetaField _requiredPreviousCamera = new();
        [FieldAttr(320)] public CCameraBaseHandleList? _allowedPreviousCameras;
        [FieldAttr(328)] public bool _superChargersBackActivationHack;
        [FieldAttr(336)] public CCameraBox? _previousCameraBox;
        [FieldAttr(344)] public CCameraBase? _camera;
        [FieldAttr(352)] public igHandleMetaField _activeCamera = new();
        [FieldAttr(360)] public CCameraBase? _explicitlyDefinedPreviousCamera;
        [FieldAttr(368)] public CCameraBlendList? _cameraBlends;
        [FieldAttr(376)] public EigEaseMode _easeMode = EigEaseMode.kEaseModeInOut;
        [FieldAttr(380)] public EigEaseType _easeType = EigEaseType.kEaseTypeCubic;
        [FieldAttr(384)] public igVec3fMetaField _targetCached = new();
        [FieldAttr(396)] public float _progressCached;
        [FieldAttr(400)] public bool _containsTargetCached;
        [FieldAttr(401)] public bool _isEnabled = true;
        [FieldAttr(404)] public ECameraBoxState _state;
        [FieldAttr(408)] public ECameraModelBlendType _blendType = ECameraModelBlendType.eCMBT_Linear;
        [FieldAttr(416)] public CCameraBoxPeachesCallback? _peachesCallback;
        [FieldAttr(424)] public ECameraBoxSide _activatedSide = CCameraBox.ECameraBoxSide.eCBS_None;
    }
}
