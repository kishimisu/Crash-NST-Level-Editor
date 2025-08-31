namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CVehicleCollisionResponse : igObject
    {
        [FieldAttr(16)] public CVehicleSystemData.EVehicleCollisionReaction _reaction;
        [FieldAttr(24)] public CVehicleCollisionExtraResponseBase? _extraResponse;
        [FieldAttr(32)] public igHandleMetaField _hitEffect = new();
        [FieldAttr(40)] public string? _hitEffectCooldownGroup = null;
        [FieldAttr(48)] public float _hitEffectCooldownDuration;
        [FieldAttr(52)] public EVehicleCollisionTweakAxis _tweakAxis = EVehicleCollisionTweakAxis.eVCTA_None;
        [FieldAttr(56)] public float _physicalResponseFactor = 1.0f;
        [FieldAttr(60)] public igVec3fMetaField _physicalRotationFactor = new();
        [FieldAttr(72)] public bool _shouldRemoveBoosts = true;
    }
}
