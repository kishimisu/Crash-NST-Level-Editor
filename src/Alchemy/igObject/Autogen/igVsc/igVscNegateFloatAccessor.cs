namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscNegateFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _value;
    }
}
