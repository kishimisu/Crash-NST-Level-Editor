namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CRigMovementController : CStackCameraControllerBase
    {
        [FieldAttr(56)] public float _dampingXY = 0.15f;
        [FieldAttr(60)] public float _dampingZ = 1.0f;
        [FieldAttr(64)] public bool _applyLookAhead;
        [FieldAttr(68)] public float _dampingLookAhead = 0.15f;
        [FieldAttr(72)] public float _dampingLookAheadReturn = 0.03f;
        [FieldAttr(76)] public float _lookAheadDistance = 200.0f;
        [FieldAttr(80)] public CStackBlender.EBlendType _yawBlendType;
        [FieldAttr(84)] public bool _debugDrawTargetInfo = true;
    }
}
