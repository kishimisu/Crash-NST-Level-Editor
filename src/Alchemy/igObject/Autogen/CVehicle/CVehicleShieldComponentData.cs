namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CVehicleShieldComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igHandleMetaField _shieldsDamagedEffect = new();
        [FieldAttr(32)] public igHandleMetaField _shieldsRecoveredEffect = new();
        [FieldAttr(40)] public igHandleMetaField _shieldsBrokenEffect = new();
        [FieldAttr(48)] public igHandleMetaField _shieldsRestoredEffect = new();
        [FieldAttr(56)] public igHandleMetaField _shieldsUpLoopEffect = new();
        [FieldAttr(64)] public igHandleMetaField _shieldsLowLoopEffect = new();
        [FieldAttr(72)] public float _shieldsLowThreshold = 0.2f;
        [FieldAttr(80)] public igHandleMetaField _shieldsDownLoopEffect = new();
        [FieldAttr(88)] public CBoltPoint? _shieldEffectsBoltPoint;
        [FieldAttr(96)] public CDifficultySpecificFloat? _shieldPercentRegainedOnSkylanderDeath;
        [FieldAttr(104)] public bool _splitDamage;
    }
}
