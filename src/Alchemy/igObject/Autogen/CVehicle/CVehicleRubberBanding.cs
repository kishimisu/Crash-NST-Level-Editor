namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CVehicleRubberBanding : igObject
    {
        [FieldAttr(16)] public float _distanceForMaxRubberBanding = 5.0f;
        [FieldAttr(20)] public float _boostDurationMultiplier = 1.0f;
        [FieldAttr(24)] public float _boostForceMultiplier = 1.0f;
        [FieldAttr(28)] public float _powerUpDurationMultiplier = 1.0f;
        [FieldAttr(32)] public float _ammoRegenRateMultiplier = 1.0f;
        [FieldAttr(36)] public float _deathDurationMultiplier = 1.0f;
    }
}
