namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscIntToEnumAccessor : igVscEnumAccessor
    {
        [FieldAttr(24)] public igVscIntAccessor? _accessor;
    }
}
