namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CVehicleCollisionExtraResponseMaintainSpeed : CVehicleCollisionExtraResponseReorientBase
    {
        [FieldAttr(64)] public igVec3fMetaField _projectedVelocityFactor = new();
        [FieldAttr(76)] public bool _useCurrentRigidBodySpeed;
    }
}
