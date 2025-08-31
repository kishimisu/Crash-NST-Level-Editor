namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CWaypoint : igObject
    {
        [FieldAttr(16)] public bool _occupied;
        [FieldAttr(20)] public igVec3fMetaField _position = new();
        [FieldAttr(32)] public igVec3fMetaField _rotation = new();
    }
}
