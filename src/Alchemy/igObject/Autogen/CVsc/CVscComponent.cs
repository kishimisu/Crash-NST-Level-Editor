namespace Alchemy
{
    [ObjectAttr(64, 8, metaObject: true)]
    public class CVscComponent : CEntityComponent
    {
        [FieldAttr(48)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(56, false)] public igMetaObject? _meta = (null);
    }
}
