namespace Alchemy
{
    [ObjectAttr(288, 8)]
    public class CActorData : CPhysicalEntityData
    {
        public enum EActorDataFlags : uint
        {
            eADF_None = 0,
            eADF_SpawnExactLocation = 16,
        }

        [FieldAttr(144)] public uint _actorDataFlags = 16;
        [FieldAttr(152)] public string? _character = null;
        [FieldAttr(160)] public string? _skin = null;
        [FieldAttr(168)] public string? _magicMomentModel = null;
        [FieldAttr(176)] public float _magicMomentSpawnBackgroundVfxOverrideTime = -1.0f;
        [FieldAttr(180)] public float _magicMomentSpawnOutroVfxOverrideTime = -1.0f;
        [FieldAttr(184)] public float _magicMomentStartEndVfxOverrideTime = -1.0f;
        [FieldAttr(188)] public float _magicMomentShowNameOverrideTime = -1.0f;
        [FieldAttr(192)] public float _magicMomentHideNameOverrideTime = -1.0f;
        [FieldAttr(196)] public float _magicMomentPauseIntroAnimationOverrideTime = -1.0f;
        [FieldAttr(200)] public float _magicMomentJumpOutTimeFromEndOverride = -1.0f;
        [FieldAttr(208)] public string? _characterAnimations = null;
        [FieldAttr(216)] public string? _characterAnimationBase = null;
        [FieldAttr(224)] public CAudioArchiveHandleList? _soundBankHandleList;
        [FieldAttr(232)] public string? _characterScript = null;
        [FieldAttr(240)] public float _aiAlertRange;
        [FieldAttr(244)] public EAllowedHitReactDirections _takeHitReactDirections = EAllowedHitReactDirections.eAHRD_NoDirection;
        [FieldAttr(248)] public EAllowedHitReactDirections _partialHitReactDirections;
        [FieldAttr(252)] public EAllowedHitReactDirections _knockawayReactDirections = EAllowedHitReactDirections.eAHRD_NoDirection;
        [FieldAttr(256)] public EAllowedHitReactDirections _deathReactDirections = EAllowedHitReactDirections.eAHRD_Front;
        [FieldAttr(260)] public EAllowedHitReactDirections _knockawayDeathReactDirections;
        [FieldAttr(264)] public igHandleMetaField _hudPortrait = new();
        [FieldAttr(272)] public igHandleMetaField _footstepEffect = new();
        [FieldAttr(280)] public igHandleMetaField _magicMomentNameEffect = new();
    }
}
