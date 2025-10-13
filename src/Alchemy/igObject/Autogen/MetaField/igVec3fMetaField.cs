namespace Alchemy
{
    [ObjectAttr(12, 8)]
    public class igVec3fMetaField : igMetaField
    {
        [FieldAttr(0)] public float _x;
        [FieldAttr(4)] public float _y;
        [FieldAttr(8)] public float _z;

        public igVec3fMetaField() { }
        public igVec3fMetaField(float x = 0, float y = 0, float z = 0) : base() { _x = x; _y = y; _z = z; }
    }
}
