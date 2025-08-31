namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CMaintainTargetHeadingController : CStackCameraControllerBase
    {
        [FieldAttr(56)] public CStackBlender.EBlendType _yawBlendType;
        [FieldAttr(60)] public bool _alwaysFaceForward;
        [FieldAttr(64)] public float _yawDampingMin = 0.05f;
        [FieldAttr(68)] public float _yawDampingMid = 0.08f;
        [FieldAttr(72)] public float _yawDampingMax = 0.03f;
        [FieldAttr(76)] public float _yawDampingInAir = 0.01f;
        [FieldAttr(80)] public float _yawDampingForcedReorient = 0.1f;
        [FieldAttr(84)] public float _angleToStartMaintainHeading = 10.0f;
        [FieldAttr(88)] public float _angleToDivideMaintainHeading = 90.0f;
        [FieldAttr(92)] public float _angleToEndMaintainHeading = 150.0f;
        [FieldAttr(96)] public float _durationRunningBeforeMaintainHeading = 0.1f;
        [FieldAttr(100)] public bool _headingBasedOnVelocity;
    }
}
