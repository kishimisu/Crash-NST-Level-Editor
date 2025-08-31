namespace Alchemy
{
    // VSC object extracted from: common_Generic_Path_Platform_SwapGameMode.igz

    [ObjectAttr(48, metaType: typeof(CVscComponentData))]
    public class common_Generic_Path_Platform_SwapGameModeData : CVscComponentData
    {
        public enum ENewEnum16_id_9et3dr1r
        {
            DontChange = 0,
            ToLevelDefault = 1,
            ToGameMode = 2,
        }

        [FieldAttr(40)] public ENewEnum16_id_9et3dr1r _NewEnum16_id_9et3dr1r;
        [FieldAttr(44)] public EWorldGameplayMode _E_World_Gameplay_Mode;
    }
}
