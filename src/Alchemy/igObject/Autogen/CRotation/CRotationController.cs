namespace Alchemy
{
    [ObjectAttr(208, 16)]
    public class CRotationController : CBaseMovementController
    {
        public enum ERotationMode : uint
        {
            eRM_Reliable = 0,
            eRM_Additive = 1,
        }

        public enum ERotationSource : uint
        {
            eRS_Auto = 0,
            eRS_AngleOffset = 1,
            eRS_AxisSpeed = 2,
            eRS_AxisTime = 3,
        }

        [FieldAttr(56)] public igVec3fMetaField _rotationAxis = new();
        [FieldAttr(68)] public igVec3fMetaField _offset = new();
        [FieldAttr(80)] public igHandleMetaField _pivotEntity = new();
        [FieldAttr(88)] public bool _facePivot = true;
        [FieldAttr(92)] public float _degreesToRotate = 360.0f;
        [FieldAttr(96)] public bool _isLocalRotation;
        [FieldAttr(97)] public bool _replicateSlider = true;
        [FieldAttr(100)] public ESliderMode _mode;
        [FieldAttr(104)] public ERotationMode _rotationMode;
        [FieldAttr(108)] public float _duration = 1.0f;
        [FieldAttr(112)] public EigEaseType _easeType = EigEaseType.kEaseTypeQuadratic;
        [FieldAttr(116)] public float _easeIn;
        [FieldAttr(120)] public float _easeOut;
        [FieldAttr(124)] public float _forcedSpeed = 3.4028234663852886e+38f;
        [FieldAttr(128)] public CSlider? _slider;
        [FieldAttr(136)] public float _previousSliderValue;
        [FieldAttr(140)] public igVec3fMetaField _axis = new();
        [FieldAttr(160)] public igQuaternionfMetaField _sourceOrientation = new();
        [FieldAttr(176)] public igQuaternionfMetaField _targetOrientation = new();
        [FieldAttr(192)] public bool _reachedTargetOrientation;
        [FieldAttr(196)] public ERotationSource _rotationSource;
    }
}
