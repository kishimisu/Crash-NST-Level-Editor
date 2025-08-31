namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class CLinearDriftData : CDriftData
    {
        [FieldAttr(72)] public float _speedRequiredForLinearDrifting = 1000.0f;
        [FieldAttr(76)] public float _joystickAddedVisualTurn = 4.0f;
        [FieldAttr(80)] public float _joystickAddedVisualTurnDamping = 0.2f;
        [FieldAttr(84)] public float _driftFakeTurnMultiplier = 0.75f;
        [FieldAttr(88)] public float _driftFakeTurnBaseValue = 15.0f;
        [FieldAttr(92)] public float _driftDistanceLevel2 = 5000.0f;
        [FieldAttr(96)] public float _driftDistanceLevel3 = 1.0f;
        [FieldAttr(100)] public float _driftStartFakeTurnTime = 0.2f;
        [FieldAttr(104)] public CLinearDriftSteeringOverride? _noBoostSteeringOverride;
        [FieldAttr(112)] public CLinearDriftSteeringOverride? _boostLevel2SteeringOverride;
        [FieldAttr(120)] public CLinearDriftSteeringOverride? _boostLevel3SteeringOverride;
        [FieldAttr(128)] public bool _boostTorwardsVelocity;
    }
}
