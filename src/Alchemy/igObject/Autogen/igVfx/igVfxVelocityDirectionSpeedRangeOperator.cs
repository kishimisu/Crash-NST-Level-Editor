namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class igVfxVelocityDirectionSpeedRangeOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(48)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(64)] public igRangedFloatMetaField _speed = new();
    }
}
