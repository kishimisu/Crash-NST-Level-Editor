namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Death_Path_Platform_StartData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Bool_Variable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Game_Bool_Variable_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public EWorldGameplayMode _E_World_Gameplay_Mode;
    }
}
