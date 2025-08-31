namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CConeShape : CShape
    {
        [FieldAttr(16)] public igVec3fMetaField _bottom = new();
        [FieldAttr(28)] public igVec3fMetaField _top = new();
        [FieldAttr(40)] public float _bottomRadius = 100.0f;
        [FieldAttr(44)] public int _segments = 8;
    }
}
