namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class igCharMetrics : igObject
    {
        [FieldAttr(16)] public u16 _charNumber;
        [FieldAttr(20)] public float _kernLeft;
        [FieldAttr(24)] public float _kernRight;
        [FieldAttr(28)] public float _step;
        [FieldAttr(32)] public igVec2fMetaField _offset = new();
        [FieldAttr(40)] public igVec2fMetaField _size = new();
        [FieldAttr(48)] public igVec2fMetaField _texCoordMin = new();
        [FieldAttr(56)] public igVec2fMetaField _texCoordMax = new();
    }
}
