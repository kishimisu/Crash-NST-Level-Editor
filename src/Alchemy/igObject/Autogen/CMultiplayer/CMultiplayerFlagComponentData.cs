namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 264, align: 8)]
    public class CMultiplayerFlagComponentData : CEntityComponentData
    {
        public enum EMultiplayerFlagType
        {
            eMFT_FreeForAll = 0,
            eMFT_Team = 1,
        }

        [FieldAttr(nst: 24, ctr: 16)] public EMultiplayerFlagType _flagType;
        [FieldAttr(nst: 28, ctr: 20)] public bool _respawnOnDrop;
        [FieldAttr(ctr: 21)] public bool _tintFlagTeamColor;
        [FieldAttr(ctr: 24)] public float _dropRespawnDelay;
        [FieldAttr(nst: 32, ctr: 28)] public int _teamIndex;
        [FieldAttr(nst: 40, ctr: 32)] public CWaypointList? _spawnLocations;
        [FieldAttr(nst: 48)] public bool _acquireOnPhysicsContact;
        [FieldAttr(nst: 49)] public bool _acquireOnTriggerTouch;
        [FieldAttr(nst: 52, ctr: 40)] public float _dropGroundHeight = 100.0f;
        [FieldAttr(nst: 56)] public float _dropDistanceBehind = 150.0f;
        [FieldAttr(ctr: 44)] public float _dropRadius;
        [FieldAttr(ctr: 48)] public float _dropRadiusMin;
        [FieldAttr(ctr: 52)] public float _defaultScale;
        [FieldAttr(ctr: 56)] public float _carriedScale;
        [FieldAttr(nst: 60, ctr: 60)] public float _groundCheckUpDistance = 1000.0f;
        [FieldAttr(nst: 64, ctr: 64)] public float _groundCheckDownDistance = 1000.0f;
        [FieldAttr(ctr: 68)] public float _wallCheckHeight;
        [FieldAttr(ctr: 72)] public float _wallDropOffset;
        [FieldAttr(nst: 68, ctr: 76)] public float _dropReaquireTimeout = 0.5f;
        [FieldAttr(ctr: 80)] public CKartMaxSpeedModifierData? _flagSpeedModifier;
        [FieldAttr(ctr: 88)] public igHandleMetaField _flagMaterialKey = new();
        [FieldAttr(ctr: 96)] public igHandleMetaField _flagMaterialDefault = new();
        [FieldAttr(ctr: 104)] public igHandleMetaField _flagMaterialAccelerating = new();
        [FieldAttr(ctr: 112)] public igFxMaterialHandleList? _flagMaterialsAccelerating;
        [FieldAttr(ctr: 120)] public float _topSpeedForAcceleratingMaterials;
        [FieldAttr(ctr: 128)] public CGameEntity? _flag;
        [FieldAttr(ctr: 136)] public float _animationBlendTime;
        [FieldAttr(ctr: 144)] public string? _acceleratingAnimation;
        [FieldAttr(ctr: 152)] public string? _idleHeldAnimation;
        [FieldAttr(ctr: 160)] public string? _idleFreeAnimation;
        [FieldAttr(ctr: 168)] public igVfxRangedCurveMetaField _popOutCurve = new();
        [FieldAttr(ctr: 252)] public float _popOutDuration;
        [FieldAttr(ctr: 256)] public igHandleMetaField _kartBolt = new();
    }
}
