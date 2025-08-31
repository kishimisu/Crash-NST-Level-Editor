namespace Alchemy
{
    [ObjectAttr(144, 16)]
    public class igVfxRotateAxisAngleCurveOperator : igVfxRotateAxisAngleBaseOperator
    {
        [FieldAttr(48)] public igVfxRangedCurveMetaField _angle = new();
        [FieldAttr(132)] public EOperatorCurveInput _angleInput;
    }
}
