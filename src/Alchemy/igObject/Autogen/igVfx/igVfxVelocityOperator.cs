namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxVelocityOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(48)] public igVec3fAlignedMetaField _velocity = new();
    }
}
