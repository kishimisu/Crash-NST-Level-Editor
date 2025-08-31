namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CVehicleSection : igObject
    {
        [FieldAttr(16)] public float _cameraBlendTime = 1.0f;
        [FieldAttr(24)] public CCameraBase? _defaultCamera;
        [FieldAttr(32)] public igHandleMetaField _splineEntity = new();
        [FieldAttr(40)] public igSpline2? _spline2;
        [FieldAttr(48)] public CLinearVehicleSplineMover? _splineMover;
        [FieldAttr(56)] public float _splineBaseMovementSpeed = 2500.0f;
        [FieldAttr(64)] public igHandleMetaField _vehicleSettingsOverride = new();
    }
}
