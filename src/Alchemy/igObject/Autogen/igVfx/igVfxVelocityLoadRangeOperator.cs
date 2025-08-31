namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxVelocityLoadRangeOperator : igVfxVelocityLoadBaseOperator
    {
        [FieldAttr(32)] public igRangedFloatMetaField _inheritedVelocity = new();
    }
}
