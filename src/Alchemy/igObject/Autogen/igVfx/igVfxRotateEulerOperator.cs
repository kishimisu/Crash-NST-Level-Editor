namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxRotateEulerOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _eulerAngles = new();
    }
}
