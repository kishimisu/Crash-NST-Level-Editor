namespace Alchemy
{
    [ObjectAttr(272, 8)]
    public class CVehicleComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igComponentDataTable? _arenaComponentTable;
        [FieldAttr(32)] public igComponentDataTable? _linearComponentTable;
        [FieldAttr(40)] public igComponentDataTable? _classicComponentTable;
        [FieldAttr(48)] public igComponentDataTable? _expeditionComponentTable;
        [FieldAttr(56)] public string? _enterArenaEvent = "Locomotion_Arena_Idle";
        [FieldAttr(64)] public string? _enterLinearEvent = "Locomotion_Linear_Idle";
        [FieldAttr(72)] public string? _enterClassicEvent = "Locomotion_Arena_Idle";
        [FieldAttr(80)] public string? _enterExpeditionEvent = null;
        [FieldAttr(88)] public CVehicleRiderComponentData? _riderComponent;
        [FieldAttr(96)] public CBoltPoint? _primaryModCameraLookAtBolt;
        [FieldAttr(104)] public CBoltPoint? _primaryModCameraPositionBolt;
        [FieldAttr(112)] public float _primaryModCameraFov = 80.0f;
        [FieldAttr(120)] public CBoltPoint? _primaryModVortexBolt;
        [FieldAttr(128)] public igVec2fMetaField _primaryModGuiPosition = new();
        [FieldAttr(136)] public CBoltPoint? _secondaryModCameraLookAtBolt;
        [FieldAttr(144)] public CBoltPoint? _secondaryModCameraPositionBolt;
        [FieldAttr(152)] public float _secondaryModCameraFov = 80.0f;
        [FieldAttr(160)] public CBoltPoint? _secondaryModVortexBolt;
        [FieldAttr(168)] public igVec2fMetaField _secondaryModGuiPosition = new();
        [FieldAttr(176)] public CBoltPoint? _hornCameraLookAtBolt;
        [FieldAttr(184)] public CBoltPoint? _hornCameraPositionBolt;
        [FieldAttr(192)] public float _hornCameraFov = 80.0f;
        [FieldAttr(200)] public CBoltPoint? _hornVortexBolt;
        [FieldAttr(208)] public igVec2fMetaField _hornGuiPosition = new();
        [FieldAttr(216)] public CBoltPoint? _antennaCameraLookAtBolt;
        [FieldAttr(224)] public CBoltPoint? _antennaCameraPositionBolt;
        [FieldAttr(232)] public float _antennaCameraFov = 80.0f;
        [FieldAttr(240)] public CBoltPoint? _antennaVortexBolt;
        [FieldAttr(248)] public igVec2fMetaField _antennaGuiPosition = new();
        [FieldAttr(256)] public float _vehiclePortalDelay = 0.5f;
        [FieldAttr(260)] public bool _gunnerCanBePassenger;
        [FieldAttr(264)] public EVehicleType _vehicleType;
    }
}
