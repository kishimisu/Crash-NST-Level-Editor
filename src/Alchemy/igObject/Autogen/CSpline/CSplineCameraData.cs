namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CSplineCameraData : igObject
    {
        public enum ERelativeOffsetSource : uint
        {
            eROS_SplineRelative = 0,
            eROS_CameraRelative = 1,
        }

        [FieldAttr(16)] public ESplineMode _splineCameraMode;
        [FieldAttr(20)] public EStartDistanceDirection _startDistanceDirection;
        [FieldAttr(24)] public float _minDistanceDuringForwardMovement;
        [FieldAttr(28)] public float _minDistanceDuringBackwardMovement;
        [FieldAttr(32)] public float _minDistanceDuringVerticalMovement = -300.0f;
        [FieldAttr(36)] public float _pitchOffsetDuringForwardMovement;
        [FieldAttr(40)] public float _pitchOffsetDuringBackwardMovement;
        [FieldAttr(44)] public float _pitchOffsetDuringVerticalMovement;
        [FieldAttr(48)] public ERelativeOffsetSource _pitchRelativeSource = CSplineCameraData.ERelativeOffsetSource.eROS_CameraRelative;
        [FieldAttr(52)] public float _positionDamping = 0.15f;
        [FieldAttr(56)] public float _rotationDamping = 0.1f;
        [FieldAttr(60)] public float _distanceDamping = 0.15f;
        [FieldAttr(64)] public float _directionChangeMinAngle = 25.0f;
        [FieldAttr(72)] public CPlayerFollowData? _yawPlayerFollowData;
        [FieldAttr(80)] public CPlayerFollowData? _pitchPlayerFollowData;
        [FieldAttr(88)] public CSplineOffsetData? _splineOffsetData;
        [FieldAttr(96)] public float _minSplineInputInfluence;
        [FieldAttr(100)] public float _maxSplineInputInfluence;
        [FieldAttr(104)] public float _minSplineInputInfluenceThreshold;
        [FieldAttr(108)] public float _maxSplineInputInfluenceThreshold = 15.0f;
        [FieldAttr(112)] public float _maxInputYawFollowOffset = -1.0f;
        [FieldAttr(116)] public float _maxInputYawDifference = -1.0f;
    }
}
