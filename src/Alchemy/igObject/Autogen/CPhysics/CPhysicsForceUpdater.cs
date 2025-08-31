namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CPhysicsForceUpdater))]
    public class CPhysicsForceUpdater : igUpdateable
    {
        [FieldAttr(32)] public igHandleMetaField _updater = new();
        [FieldAttr(40)] public igHandleMetaField _entity = new();
        [FieldAttr(48)] public igVec3fMetaField _force = new();
    }
}
