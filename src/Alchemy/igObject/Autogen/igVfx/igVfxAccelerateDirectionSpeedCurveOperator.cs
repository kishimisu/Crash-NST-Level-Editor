namespace Alchemy
{
    [ObjectAttr(144, 16)]
    public class igVfxAccelerateDirectionSpeedCurveOperator : igVfxAccelerateBaseOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(48)] public igVfxRangedCurveMetaField _acceleration = new();
        [FieldAttr(132)] public EOperatorCurveInput _accelerationInput;
    }
}
