namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxAccelerateOperator : igVfxAccelerateBaseOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _acceleration = new();
    }
}
