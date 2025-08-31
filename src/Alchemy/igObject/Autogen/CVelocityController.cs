namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVelocityController : CBaseMovementController
    {
        [FieldAttr(56)] public float _speed;
        [FieldAttr(60)] public igVec3fMetaField _direction = new();
        [FieldAttr(72)] public igVec3fMetaField _destination = new();
    }
}
