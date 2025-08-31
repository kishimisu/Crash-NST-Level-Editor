namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVscComponentEntityToComponentAccessor : igVscObjectAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _accessor;
        [FieldAttr(32, false)] public igMetaObject? _componentMeta;
    }
}
