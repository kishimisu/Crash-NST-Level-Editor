namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CCoreCameraController : CStackCameraControllerBase
    {
        [FieldAttr(56)] public float _targetDistance = 450.0f;
        [FieldAttr(60)] public float _distanceDamping = 0.07f;
        [FieldAttr(64)] public CStackBlender.EBlendType _distanceBlendType;
        [FieldAttr(68)] public float _yawDamping = 0.05f;
        [FieldAttr(72)] public CStackBlender.EBlendType _yawBlendType;
        [FieldAttr(76)] public bool _applyTargetPitch;
        [FieldAttr(80)] public float _targetPitch = 15.0f;
        [FieldAttr(84)] public float _pitchDamping = 0.04f;
        [FieldAttr(88)] public CStackBlender.EBlendType _pitchBlendType;
        [FieldAttr(92)] public float _targetRoll;
        [FieldAttr(96)] public float _rollDamping = 0.1f;
        [FieldAttr(100)] public CStackBlender.EBlendType _rollBlendType;
        [FieldAttr(104)] public float _targetFov = 80.0f;
        [FieldAttr(108)] public float _fovDamping = 0.1f;
        [FieldAttr(112)] public CStackBlender.EBlendType _fovBlendType;
        [FieldAttr(116)] public float _targetHorizontalOffset;
        [FieldAttr(120)] public float _horizontalOffsetDamping = 0.3f;
        [FieldAttr(124)] public CStackBlender.EBlendType _horizontalOffsetBlendType;
        [FieldAttr(128)] public float _targetVerticalOffset = 100.0f;
        [FieldAttr(132)] public float _verticalOffsetDamping = 0.05f;
        [FieldAttr(136)] public CStackBlender.EBlendType _verticalOffsetBlendType;
    }
}
