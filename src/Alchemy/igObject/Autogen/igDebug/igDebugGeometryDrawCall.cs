namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igDebugGeometryDrawCall : igDrawCall
    {
        [FieldAttr(24)] public igRawRefMetaField _data = new();
        [FieldAttr(32, false)] public igMemoryCommandStream? _state;
    }
}
