namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscNegateBoolAccessor : igVscBoolAccessor
    {
        [FieldAttr(24)] public igVscBoolAccessor? _value;
    }
}
