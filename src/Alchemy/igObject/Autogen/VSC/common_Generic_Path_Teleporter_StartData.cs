namespace Alchemy
{
    // VSC object extracted from: common_Generic_Path_Teleporter_Start.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_Generic_Path_Teleporter_StartData : CVscComponentData
    {
        public enum ENewEnum16_id_noksmwgb
        {
            DontChange = 0,
            ToLevelDefault = 1,
            ToGameMode = 2,
        }

        [FieldAttr(40)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(48)] public igHandleMetaField _minigamePreset = new();
        [FieldAttr(56)] public igHandleMetaField _Entity = new();
        [FieldAttr(64)] public igHandleMetaField _common_Gem_Platform_SplineDatas001 = new();
        [FieldAttr(72)] public igHandleMetaField _CameraProxy = new();
        [FieldAttr(80)] public igHandleMetaField _Spline = new();
        [FieldAttr(88)] public ENewEnum16_id_noksmwgb _NewEnum16_id_noksmwgb;
        [FieldAttr(92)] public EWorldGameplayMode _E_World_Gameplay_Mode;
        [FieldAttr(96)] public bool _Bool;
    }
}
