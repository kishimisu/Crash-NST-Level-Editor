namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class COcclusionController : CStackCameraControllerBase
    {
        [FieldAttr(56)] public float _yawDamping = 0.05f;
        [FieldAttr(60)] public float _yawDeltaRequest = 90.0f;
        [FieldAttr(64)] public float _forwardBackwardAngle = 40.0f;
        [FieldAttr(68)] public bool _debugDrawWhiskers = true;
        [FieldAttr(69)] public bool _debugDrawHeading = true;
    }
}
