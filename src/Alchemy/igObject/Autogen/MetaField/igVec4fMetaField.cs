namespace Alchemy
{
    [ObjectAttr(16, 8)]
    public class igVec4fMetaField : igMetaField
    {
        [FieldAttr(0)] public float _x;
        [FieldAttr(4)] public float _y;
        [FieldAttr(8)] public float _z;
        [FieldAttr(12)] public float _w;
    }
}
