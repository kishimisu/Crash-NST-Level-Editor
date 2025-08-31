namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CFilterByComponent : CFilterMethod
    {
        [FieldAttr(24)] public igHandleMetaField _componentType = new();
    }
}
