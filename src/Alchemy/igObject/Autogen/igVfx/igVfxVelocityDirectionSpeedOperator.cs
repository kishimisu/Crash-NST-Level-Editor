namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class igVfxVelocityDirectionSpeedOperator : igVfxVelocityBaseOperator
    {
        [FieldAttr(48)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(64)] public float _speed;
    }
}
