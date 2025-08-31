namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGuiVscUpdaterAccessor : igVscObjectAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _accessor;
    }
}
