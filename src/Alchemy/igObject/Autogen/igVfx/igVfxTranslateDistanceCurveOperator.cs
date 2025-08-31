namespace Alchemy
{
    [ObjectAttr(144, 16)]
    public class igVfxTranslateDistanceCurveOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(48)] public igVfxRangedCurveMetaField _distance = new();
        [FieldAttr(132)] public EOperatorCurveInput _distanceInput;
    }
}
