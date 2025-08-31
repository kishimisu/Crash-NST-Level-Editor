namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxRotateAxisAngleRangeOperator : igVfxRotateAxisAngleBaseOperator
    {
        [FieldAttr(48)] public igRangedFloatMetaField _angle = new();
    }
}
