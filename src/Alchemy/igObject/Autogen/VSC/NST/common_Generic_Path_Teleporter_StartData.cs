namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Generic_Path_Teleporter_StartData : CVscComponentData
    {
        public enum ENewEnum16_id_noksmwgb
        {
            DontChange = 0,
            ToLevelDefault = 1,
            ToGameMode = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _minigamePreset = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _common_Gem_Platform_SplineDatas001 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _CameraProxy = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Spline = new();
        [FieldAttr(nst: 88, ctr: 80)] public ENewEnum16_id_noksmwgb _NewEnum16_id_noksmwgb;
        [FieldAttr(nst: 92, ctr: 84)] public EWorldGameplayMode _E_World_Gameplay_Mode;
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool;
    }
}
