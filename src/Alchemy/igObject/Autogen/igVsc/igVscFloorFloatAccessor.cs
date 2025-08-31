namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscFloorFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _value;
    }
}
