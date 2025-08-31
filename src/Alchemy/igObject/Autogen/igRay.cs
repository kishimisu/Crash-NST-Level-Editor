namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class igRay : igObject
    {
        [FieldAttr(16)] public igVec3fMetaField _pos = new();
        [FieldAttr(28)] public igVec3fMetaField _dir = new();
        [FieldAttr(40)] public float _len;
    }
}
