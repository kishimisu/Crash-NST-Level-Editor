namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class Vector3 : igObject
    {
        [FieldAttr(16)] public igVec3fMetaField _storage = new();
    }
}
