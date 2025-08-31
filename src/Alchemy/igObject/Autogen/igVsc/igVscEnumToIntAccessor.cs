namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscEnumToIntAccessor : igVscIntAccessor
    {
        [FieldAttr(24)] public igVscEnumAccessor? _accessor;
    }
}
