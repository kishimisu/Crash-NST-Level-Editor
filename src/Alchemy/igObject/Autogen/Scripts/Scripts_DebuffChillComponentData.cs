namespace Alchemy
{
    [ObjectAttr(104, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_DebuffChillComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_DebuffChillComponent_
    {
        [FieldAttr(40)] public CVfxEffectDotNetHandle? ChillFX;
        [FieldAttr(48)] public CUpgradeableVfx? UpgradeableChillFX;
        [FieldAttr(56)] public bool HardKillEffect = true;
        [FieldAttr(64)] public CBoltPoint? EffectBoltPoint;
        [FieldAttr(72)] public float ChillDuration = 1.5f;
        [FieldAttr(76)] public float ChillDurationBeforeEasing = 0.75f;
        [FieldAttr(80)] public float ChillIntensity = 0.5f;
        [FieldAttr(88)] public CDamageData? IntervalDamage;
        [FieldAttr(96)] public float IntervalDuration = 0.5f;
        [FieldAttr(100)] public bool SlowSpawnedProjectiles;
    }
}
