namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Generic_Path_Platform_SwapGameModeData : CVscComponentData
    {
        public enum ENewEnum16_id_9et3dr1r
        {
            DontChange = 0,
            ToLevelDefault = 1,
            ToGameMode = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public ENewEnum16_id_9et3dr1r _NewEnum16_id_9et3dr1r;
        [FieldAttr(nst: 44, ctr: 36)] public EWorldGameplayMode _E_World_Gameplay_Mode;
    }
}
