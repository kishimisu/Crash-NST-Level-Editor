namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CLinearDriftSteeringOverride : igObject
    {
        [FieldAttr(16)] public float magnitude = 1.0f;
        [FieldAttr(20)] public float decayDelay = 0.2f;
        [FieldAttr(24)] public float decayDuration = 0.4f;
        [FieldAttr(28)] public bool useBoostTurn = true;
    }
}
