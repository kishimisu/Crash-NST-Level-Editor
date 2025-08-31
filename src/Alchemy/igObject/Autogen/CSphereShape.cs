namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CSphereShape : CShape
    {
        [FieldAttr(16)] public igVec3fMetaField _offset = new();
        [FieldAttr(28)] public float _radius = 50.0f;
    }
}
