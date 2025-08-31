namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CCylinderShape : CShape
    {
        [FieldAttr(16)] public igVec3fMetaField _bottom = new();
        [FieldAttr(28)] public igVec3fMetaField _top = new();
        [FieldAttr(40)] public float _radius = 100.0f;
        [FieldAttr(44)] public int _numVerts = 16;
    }
}
