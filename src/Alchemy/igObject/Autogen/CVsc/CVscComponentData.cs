namespace Alchemy
{
    [ObjectAttr(40, 8, metaObject: true)]
    public class CVscComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(32, false)] public igMetaObject? _meta = (null);
    }
}
