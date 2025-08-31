namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVscPlayerNodeToEntityAccessor : igVscObjectAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _accessor;
    }
}
