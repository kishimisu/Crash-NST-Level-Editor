namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxTranslateOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _offset = new();
    }
}
