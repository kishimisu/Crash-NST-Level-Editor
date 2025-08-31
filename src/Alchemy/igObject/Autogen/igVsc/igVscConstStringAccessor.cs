namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscConstStringAccessor : igVscStringAccessor
    {
        [FieldAttr(24)] public string? _value = null;
    }
}
