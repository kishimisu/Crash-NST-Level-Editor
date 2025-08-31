namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CVehicleCollisionExtraResponseReorientBase : CVehicleCollisionExtraResponseBase
    {
        [FieldAttr(32)] public float _reorientFactor = 1.0f;
        [FieldAttr(36)] public float _reorientSteeringMagnitude;
        [FieldAttr(40)] public float _reorientSteeringDecayDelay = 0.1f;
        [FieldAttr(44)] public float _reorientSteeringDecayDuration = 0.1f;
        [FieldAttr(48)] public igVec3fMetaField _reorientAngularFactor = new();
    }
}
