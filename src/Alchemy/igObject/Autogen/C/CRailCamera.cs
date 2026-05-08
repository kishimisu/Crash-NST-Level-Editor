namespace Alchemy
{
    [ObjectAttr(nst: 480, ctr: 512, align: 16)]
    public class CRailCamera : CConstrainedCamera
    {
        [FieldAttr(nst: 432, ctr: 464)] public igSpline? _rail;
        [FieldAttr(nst: 440, ctr: 472)] public igSpline? _spline;
        [FieldAttr(nst: 448, ctr: 480)] public bool _lockRotationToSpline = true;
        [FieldAttr(nst: 449, ctr: 481)] public bool _subdivideLargeSegments;
        [FieldAttr(nst: 452, ctr: 484)] public float _maximumSegmentRatio = 0.05f;
        [FieldAttr(nst: 456, ctr: 488)] public float _positionOnSpline;
        [FieldAttr(nst: 460, ctr: 492)] public float _maxCameraSpeed = 680.0f;
        [FieldAttr(nst: 464, ctr: 496)] public CRailCameraPeachesCallback? _peachesCallback;
    }
}
