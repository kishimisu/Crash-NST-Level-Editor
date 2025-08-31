namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CBoxShape : CShape
    {
        [FieldAttr(16)] public igVec3fMetaField _offset = new();
        [FieldAttr(28)] public igVec3fMetaField _rotation = new();
        [FieldAttr(40)] public igVec3fMetaField _min = new();
        [FieldAttr(52)] public igVec3fMetaField _max = new();
    }
}
