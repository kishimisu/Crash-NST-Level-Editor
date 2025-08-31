namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CNetworkVehicleRigidbodyReplicaComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _setPositionByLinearVelocity = true;
        [FieldAttr(28)] public float _setPositionByLinearVelocityDuration = 0.5f;
        [FieldAttr(32)] public float _minPositionDeltaForSetByVelocity = 10.0f;
        [FieldAttr(36)] public float _staticPositionDeltaUntilTeleport = 2000.0f;
        [FieldAttr(40)] public float _restingPositionDeltaUntilTeleport = 50.0f;
        [FieldAttr(44)] public float _maxPredictedPositionTimeDeltaUntilTeleport = 2.0f;
        [FieldAttr(48)] public bool _useRestingGravity;
        [FieldAttr(49)] public bool _useLinearVelocity = true;
        [FieldAttr(52)] public float _minimumMovementForLinearVelocity = 5.0f;
        [FieldAttr(56)] public float _maxRacingSpeedForLinearInterpolation = 4000.0f;
    }
}
