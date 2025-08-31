namespace Alchemy
{
    [ObjectAttr(48, 8, metaObject: true)]
    public class CEntitySphere : Object
    {
        [FieldAttr(32)] public float _radius = 100.0f;
        [FieldAttr(36)] public igVec3fMetaField _offset = new();
    }
}
