namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxVelocityLoadCurveOperator : igVfxVelocityLoadBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _inheritedVelocity = new();
        [FieldAttr(116)] public EOperatorCurveInput _inheritedVelocityInput;
    }
}
