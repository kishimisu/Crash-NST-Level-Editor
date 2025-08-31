namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CCameraZoomSystem : igObject
    {
        [FieldAttr(16)] public float _stickyCameraZoomDuration = 1.0f;
        [FieldAttr(20)] public float _cameraZoomOutDampingFactor = 0.2f;
        [FieldAttr(24)] public float _cameraZoomInDampingFactor = 0.05f;
        [FieldAttr(28)] public float _previousCameraZoomDistance;
        [FieldAttr(32)] public float _stickyCameraZoomRunningTime;
        [FieldAttr(36)] public float _currentCameraZoomDistance;
        [FieldAttr(40)] public bool _isCameraZoomCapped;
        [FieldAttr(41)] public bool _isCameraZoomStickied;
        [FieldAttr(44)] public float _cameraZoomDampingVelocity;
        [FieldAttr(48)] public igPlane? _leftPlane;
        [FieldAttr(56)] public igPlane? _rightPlane;
        [FieldAttr(64)] public igPlane? _bottomPlane;
        [FieldAttr(72)] public igPlane? _topPlane;
        [FieldAttr(80)] public igRay? _ray;
    }
}
