namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class igVfxPosePlacedPrimitiveRotateOperatorBase : igVfxLoadOperator
    {
        [ObjectAttr(4)]
        public class PlacedPrimitiveFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isLockedToGroundBolt;
            [FieldAttr(1, size: 1)] public bool _isLockedToBolt;
            [FieldAttr(2, size: 1)] public bool _isBillboard;
            [FieldAttr(3, size: 1)] public bool _hackRotationFix;
            [FieldAttr(4, size: 1)] public bool _isBillboardViewPlaneAligned = false;
            [FieldAttr(5, size: 1)] public bool _isBillboardAxisAligned;
            [FieldAttr(6, size: 1)] public bool _isOrientationRandom;
            [FieldAttr(7, size: 2)] public ETransformSpace _orientationSpace = ETransformSpace.kCameraSpace;
            [FieldAttr(9, size: 1)] public bool _isRotationAxisRandom;
            [FieldAttr(10, size: 1)] public bool _isRotationAppliedToOrientation = false;
            [FieldAttr(11, size: 2)] public ETransformSpace _rotationSpace = ETransformSpace.kCameraSpace;
            [FieldAttr(13, size: 1)] public bool _useMotionPathDuration;
            [FieldAttr(14, size: 3)] public EMotionPathBehavior _motionPathBehavior = EMotionPathBehavior.kSpawnAlongPath;
        }

        [FieldAttr(32)] public PlacedPrimitiveFlags _placedPrimitiveFlags = new();
        [FieldAttr(36)] public igVec3fMetaField _orientationInfo = new();
        [FieldAttr(48)] public igVec3fMetaField _rotationAxisInternal = new();
        [FieldAttr(60)] public float _fixedRotationAngle;
        [FieldAttr(64)] public float _fixedRotationRadius;
        [FieldAttr(72)] public string? _motionModelName = null;
        [FieldAttr(80)] public string? _motionPathName = "MotionPath";
        [FieldAttr(88)] public igTransform? _motionPath;
        [FieldAttr(96)] public EReferenceFrame _spawnLocationTrack = EReferenceFrame.eRF_Track2;
    }
}
