namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxSpinOperator : igVfxSpinBaseOperator
    {
        [FieldAttr(48)] public igVec3fAlignedMetaField _spin = new();
    }
}
