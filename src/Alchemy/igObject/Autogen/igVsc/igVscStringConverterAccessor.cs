namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscStringConverterAccessor : igVscStringAccessor
    {
        [FieldAttr(24)] public igVscAccessor? _accessor;
    }
}
