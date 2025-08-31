namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class igVfxVelocityDirectionSpeedCurveOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(48)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(64)] public igVfxRangedCurveMetaField _speed = new();
        [FieldAttr(148)] public EOperatorCurveInput _speedInput;
    }
}
