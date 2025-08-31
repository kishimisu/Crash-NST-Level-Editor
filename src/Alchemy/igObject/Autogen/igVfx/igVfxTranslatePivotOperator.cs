namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxTranslatePivotOperator : igVfxOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _offset = new();
    }
}
