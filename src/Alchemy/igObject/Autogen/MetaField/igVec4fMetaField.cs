namespace Alchemy
{
    [ObjectAttr(16, 8)]
    public class igVec4fMetaField : igMetaField
    {
        [FieldAttr(0)] public float _x;
        [FieldAttr(4)] public float _y;
        [FieldAttr(8)] public float _z;
        [FieldAttr(12)] public float _w;

        public igVec4fMetaField() { }
        public igVec4fMetaField(float x = 0, float y = 0, float z = 0, float w = 0) : base() { _x = x; _y = y; _z = z; _w = w; }
    }
}
