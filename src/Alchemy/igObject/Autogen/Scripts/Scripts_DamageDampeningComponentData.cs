namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_DamageDampeningComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_DamageDampeningComponent_
    {
        [FieldAttr(40)] public float HighDampenDuration = 0.69999999f;
        [FieldAttr(44)] public float LowDampenDuration = 1.39999998f;
        [FieldAttr(48)] public float HighDampenMultiplier = 0.3f;
        [FieldAttr(52)] public float LowDampenMultiplier = 0.69999999f;
        [FieldAttr(56)] public int DamageThreshold = 10;
        [FieldAttr(60)] public float MaxPercentDamagePerHit = 0.25f;
        [FieldAttr(64)] public float MaxPercentDamagePerHitHard = 0.4f;
        [FieldAttr(68)] public float MaxPercentDamagePerHitNightmare = 0.5f;
        [FieldAttr(72)] public float NightmareGiantDamageMultiplier = 1.29999995f;
        [FieldAttr(76)] public float HardChompyDamageMultiplier = 1.39999998f;
        [FieldAttr(80)] public float NightmareChompyDamageMultiplier = 1.5f;
        [FieldAttr(84)] public int NightmareMinDamage = 217;
        [FieldAttr(88)] public float NightmareMinDamageMultiplier = 1.35f;
    }
}
