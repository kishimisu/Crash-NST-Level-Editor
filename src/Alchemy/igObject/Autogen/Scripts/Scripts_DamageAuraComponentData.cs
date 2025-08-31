namespace Alchemy
{
    [ObjectAttr(232, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_DamageAuraComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_DamageAuraComponent_
    {
        [FieldAttr(40)] public CVfxEffectDotNetHandle? AuraFx;
        [FieldAttr(48)] public CBoltPoint? BoltPoint;
        [FieldAttr(56)] public bool HardKillOnDisable;
        [FieldAttr(64)] public string? ComponentIdentifier = null;
        [FieldAttr(72)] public bool AllowSameComponentStacking = true;
        [FieldAttr(80)] public CDamageData? DamageData;
        [FieldAttr(88)] public CDamageData? DamageDataPVP;
        [FieldAttr(96)] public float Life = 3.0f;
        [FieldAttr(100)] public bool RemoveOnLifeEnd = true;
        [FieldAttr(101)] public bool RemoveOnVisibilityChange;
        [FieldAttr(104)] public float XHitOffset = 100.0f;
        [FieldAttr(108)] public float ZHitOffset = 50.0f;
        [FieldAttr(112)] public float HitCount;
        [FieldAttr(116)] public bool RemoveOnLastHit;
        [FieldAttr(117)] public bool UseHitBased;
        [FieldAttr(120)] public float HitCooldown = 1.0f;
        [FieldAttr(128)] public CPhysicalEntityData? HitBaseEntity;
        [FieldAttr(136)] public CTriggerVolumeSphereComponentData? HitTriggerVolumeData;
        [FieldAttr(144)] public float TurnSpeed;
        [FieldAttr(148)] public bool TurnRight;
        [FieldAttr(152)] public CVfxEffectDotNetHandle? PerHitVfx;
        [FieldAttr(160)] public CBoltPoint? HitVfxBolt;
        [FieldAttr(168)] public CQueryFilter? QueryData;
        [FieldAttr(176)] public float Interval = 0.2f;
        [FieldAttr(180)] public bool UseInterval = true;
        [FieldAttr(184)] public CVfxEffectDotNetHandle? IntervalAttackVfx;
        [FieldAttr(192)] public CUpgradeableVfx? IntervalAttackVfxUpgradeable;
        [FieldAttr(200)] public CBoltPoint? IntervalAttackVfxBoltPoint;
        [FieldAttr(208)] public bool IntervalUseTwoBoltVfx;
        [FieldAttr(216)] public CBoltPoint? IntervalAttackVoltVfxBoltPoint01;
        [FieldAttr(224)] public CBoltPoint? IntervalAttackVoltVfxBoltPoint02;
    }
}
