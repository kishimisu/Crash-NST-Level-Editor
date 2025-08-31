namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class igVfxSpinAxisRateRangeOperator : igVfxSpinAxisRateBaseOperator
    {
        [FieldAttr(64)] public igRangedFloatMetaField _rate = new();
    }
}
