namespace Alchemy
{
    [ObjectAttr(4, 8)]
    public class igVec4ucMetaField : igMetaField
    {
        [FieldAttr(0)] public u8 _x;
        [FieldAttr(1)] public u8 _y;
        [FieldAttr(2)] public u8 _z;
        [FieldAttr(3)] public u8 _w;
    }
}
