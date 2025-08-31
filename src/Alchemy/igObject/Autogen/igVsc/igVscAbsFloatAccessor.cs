namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscAbsFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _input;
    }
}
