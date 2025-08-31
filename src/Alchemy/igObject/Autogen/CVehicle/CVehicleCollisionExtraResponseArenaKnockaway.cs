namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CVehicleCollisionExtraResponseArenaKnockaway : CVehicleCollisionExtraResponseBase
    {
        [FieldAttr(32)] public float _minKnockawayPitch = 20.0f;
        [FieldAttr(36)] public float _maxKnockawayPitch = 90.0f;
        [FieldAttr(40)] public float _minKnockawaySpeed = 2000.0f;
        [FieldAttr(44)] public float _maxKnockawaySpeed = 5000.0f;
        [FieldAttr(48)] public bool _onDamageOnly = true;
        [FieldAttr(49)] public bool _useModifiedWeight = true;
    }
}
