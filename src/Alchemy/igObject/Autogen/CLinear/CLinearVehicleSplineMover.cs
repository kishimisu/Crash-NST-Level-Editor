namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CLinearVehicleSplineMover : igObject
    {
        [FieldAttr(16)] public float _currentSpeed;
        [FieldAttr(20)] public float _distanceOnSpline;
        [FieldAttr(24)] public CFlightControlLinearCameraSpline? _spline;
        [FieldAttr(32)] public igSpline2? _spline2;
        [FieldAttr(40)] public CSplineKeyframedVelocityMover? _splineKeyframedVelocityMover;
        [FieldAttr(48)] public float _cameraFollowDistanceOffset;
        [FieldAttr(52)] public float _boostDistanceMax;
        [FieldAttr(56)] public float _brakeDistanceMax;
        [FieldAttr(60)] public bool _igSpline2 = true;
        [FieldAttr(64)] public igHandleMetaField _primaryVehicle = new();
    }
}
