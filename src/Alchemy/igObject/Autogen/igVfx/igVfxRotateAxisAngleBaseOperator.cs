namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxRotateAxisAngleBaseOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _axis = new();
    }
}
