namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxAccelerateDirectionSpeedRangeOperator : igVfxAccelerateBaseOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(48)] public igRangedFloatMetaField _acceleration = new();
    }
}
