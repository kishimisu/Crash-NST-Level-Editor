namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class CWorldEntityData : CEntityData
    {
        [FieldAttr(56)] public uint _worldEntityFlags;
        [FieldAttr(60)] public int _forceAct;
        [FieldAttr(64)] public float _killz = -500.0f;
        [FieldAttr(68)] public EWorldGameplayMode _startingGameplayMode;
        [FieldAttr(72)] public float _airFriction;
        [FieldAttr(80)] public igHandleMetaField _traversalStream = new();
        [FieldAttr(88)] public float _overrideTraversalTrack1Volume = -1.0f;
        [FieldAttr(92)] public float _overrideTraversalAccelerationSmoothing = -1.0f;
        [FieldAttr(96)] public float _overrideTraversalDecelerationSmoothing = -1.0f;
        [FieldAttr(100)] public float _overrideTraversalZeroVolumeSpeed = -1.0f;
        [FieldAttr(104)] public float _overrideTraversalFullVolumeSpeed = -1.0f;
        [FieldAttr(108)] public float _overrideTraversalMaxSpeed = -1.0f;
        [FieldAttr(112)] public igHandleMetaField _classicDspOverrideSet = new();
        [FieldAttr(120)] public igHandleMetaField _vehicleDspOverrideSet = new();
        [FieldAttr(128)] public igHandleMetaField _combatStream = new();
        [FieldAttr(136)] public CMusicMixList? _musicMixes;
        [FieldAttr(144)] public igHandleMetaField _windGustSound = new();
        [FieldAttr(152)] public string? _unpauseScript = null;
        [FieldAttr(160)] public CNavMeshBuildDataList? _navmeshes;
        [FieldAttr(168)] public igVec3fMetaField _startFadeColor = new();
        [FieldAttr(180)] public bool _hasZeroGravity;
    }
}
