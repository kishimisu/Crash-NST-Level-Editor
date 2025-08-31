namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igSpline : igSplinePointList
    {
        public enum ESplineInterpolationMode : uint
        {
            eSIM_Curved = 0,
            eSIM_CurvedBezier = 1,
            eSIM_Linear = 2,
        }

        public enum ERotationMode : uint
        {
            kTangent = 0,
            kInterpolated = 1,
        }

        [FieldAttr(40)] public float _length;
        [FieldAttr(44)] public ESplineInterpolationMode _mode;
        [FieldAttr(48)] public ERotationMode _rotationMode = igSpline.ERotationMode.kInterpolated;
        [FieldAttr(52)] public bool _loopControlPoints;
        [FieldAttr(56)] public float _tensionParameter = 0.4f;
    }
}
