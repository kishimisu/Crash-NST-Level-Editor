namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxRotateAxisAngleRangedRampOperator : igVfxRotateAxisAngleBaseOperator
    {
        [FieldAttr(48)] public igVfxRangedRampMetaField _angle = new();
    }
}
