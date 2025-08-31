namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igHandleMetaFieldInstance : igRefMetaFieldInstance
    {
        [FieldAttr(56, false)] public igMemoryRef<igHandleMetaField> _default = new();
        [FieldAttr(80, false)] public igMetaObject? _metaObject;
    }
}
