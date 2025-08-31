namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class COrbitComponentData : CEntityComponentData
    {
        public enum EOrbitComponentDistanceType : uint
        {
            PingPong = 0,
            UseMinDistance = 1,
            UseMaxDistance = 2,
        }

        public enum EOrbitComponentOrientationType : uint
        {
            eOCOT_DoNotOrient = 0,
            eOCOT_Spin = 1,
            eOCOT_FaceOrbitAroundEntity = 2,
            eOCOT_FaceDirectionOfOrbitAroundEntity = 3,
            eOCOT_FaceDirectionOfOrbit = 4,
        }

        [FieldAttr(24)] public bool AlwaysSetupOnStart;
        [FieldAttr(25)] public bool AuthorityOnly;
        [FieldAttr(32)] public igHandleMetaField OrbitAroundEntity = new();
        [FieldAttr(40)] public bool DoOrbitAroundParent;
        [FieldAttr(48)] public CBoltPoint? OrbitBoltPoint;
        [FieldAttr(56)] public Vector3? OrbitAroundAxis;
        [FieldAttr(64)] public bool LocalAxis;
        [FieldAttr(65)] public bool UseInitialAngles;
        [FieldAttr(66)] public bool UseInitialPosition;
        [FieldAttr(72)] public Vector3? InitialAngleOffset;
        [FieldAttr(80)] public EOrbitComponentDistanceType DistanceType;
        [FieldAttr(88)] public RangedFloat? Distance;
        [FieldAttr(96)] public float Period = -1.0f;
        [FieldAttr(100)] public float ExpandTime = -1.0f;
        [FieldAttr(104)] public float MaxWobble = -1.0f;
        [FieldAttr(108)] public float WobbleTime = -1.0f;
        [FieldAttr(112)] public bool OrbitOnStart;
        [FieldAttr(116)] public float TransitionTime = -1.0f;
        [FieldAttr(120)] public EOrbitComponentOrientationType OrientationType;
        [FieldAttr(128)] public Vector3? SpinAxis;
        [FieldAttr(136)] public float SpinPeriod = 1.0f;
    }
}
