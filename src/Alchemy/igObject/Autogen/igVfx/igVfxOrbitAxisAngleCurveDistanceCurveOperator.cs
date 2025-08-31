namespace Alchemy
{
    [ObjectAttr(240, 16)]
    public class igVfxOrbitAxisAngleCurveDistanceCurveOperator : igVfxOrbitAxisAngleDistanceBaseOperator
    {
        [FieldAttr(64)] public igVfxRangedCurveMetaField _angle = new();
        [FieldAttr(148)] public EOperatorCurveInput _angleInput;
        [FieldAttr(152)] public igVfxRangedCurveMetaField _radius = new();
        [FieldAttr(236)] public EOperatorCurveInput _radiusInput;
    }
}
