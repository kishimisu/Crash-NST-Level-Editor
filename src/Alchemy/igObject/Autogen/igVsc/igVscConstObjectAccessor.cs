namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscConstObjectAccessor : igVscObjectAccessor
    {
        [FieldAttr(24)] public igHandleMetaField _value = new();
    }
}
