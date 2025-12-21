namespace Alchemy
{
    [ObjectAttr(8, 8)]
    public class igVec2fMetaField : igMetaField
    {
        [FieldAttr(0)] public float _x;
        [FieldAttr(4)] public float _y;

        public igVec2fMetaField() { }
        public igVec2fMetaField(float x = 0, float y = 0) { _x = x; _y = y; }
    }
}
