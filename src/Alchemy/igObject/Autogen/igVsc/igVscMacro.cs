namespace Alchemy
{
    [ObjectAttr(32, 8, metaObject: true)]
    public class igVscMacro : igObject
    {
        [FieldAttr(16)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(24, false)] public igMetaObjectInstance? _meta = (null);
    }
}
