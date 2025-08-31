namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class DotNetDataMetaField : igCustomIGZSaverMetaField
    {
        [FieldAttr(0)] public igObject? _elementRef; // ROFS
        [FieldAttr(8, false)] public igObject? _elementClass; // RNEX
        [FieldAttr(16)] public u64 _elementType; // always 0x0, 0x1C or 0x40000001
        [FieldAttr(24)] public u64 _0x18; // always 0x0 or 0x00010001
    }
}