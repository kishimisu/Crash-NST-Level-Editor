namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Death_Path_Platform_Start_SpawnedData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Bool_Variable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Game_Bool_Variable_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Model_Info = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _PlayerDeathCount = new();
    }
}
