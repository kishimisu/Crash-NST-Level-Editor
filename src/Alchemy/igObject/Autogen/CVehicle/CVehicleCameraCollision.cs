namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CVehicleCameraCollision : igObject
    {
        [FieldAttr(16)] public float collisionOutDampingFactor = 0.05f;
        [FieldAttr(20)] public float _rayWidth = 20.0f;
        [FieldAttr(24)] public bool _enabled = true;
        [FieldAttr(25)] public bool _debug;
        [FieldAttr(32)] public CCollisionMaterialHandleList? _ignoreCollisionMaterialsList;
        [FieldAttr(40)] public float _collisionOutVelocity;
        [FieldAttr(44)] public float _lastCollisionFraction = 1.0f;
    }
}
