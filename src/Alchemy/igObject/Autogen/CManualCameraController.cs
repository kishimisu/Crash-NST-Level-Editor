namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CManualCameraController : CStackCameraControllerBase
    {
        [FieldAttr(56)] public CStackBlender.EBlendType _horizontalRotationBlendType;
        [FieldAttr(60)] public CStackBlender.EBlendType _verticalRotationBlendType;
        [FieldAttr(64)] public bool _affectPitch = true;
        [FieldAttr(65)] public bool _affectYaw = true;
        [FieldAttr(68)] public float _horizontalRotationSpeed = 25.0f;
        [FieldAttr(72)] public float _horizontalRotationDamping = 0.1f;
        [FieldAttr(76)] public float _verticalRotationSpeed = 20.0f;
        [FieldAttr(80)] public float _verticalRotationDamping = 0.08f;
        [FieldAttr(84)] public float _verticalMinRange = -10.0f;
        [FieldAttr(88)] public float _verticalMaxRange = 40.0f;
        [FieldAttr(92)] public float _runningDurationToMaintainManualViewPitch = 1.0f;
        [FieldAttr(96)] public float _runningDurationToMaintainManualViewYaw = 1.0f;
        [FieldAttr(100)] public bool _debugDrawSticks = true;
    }
}
