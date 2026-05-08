namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class DDA_CheckpointData : CVscComponentData
    {
        public enum ENewEnum12_id_kxje8bmu
        {
            Checkpoint = 0,
            AkuAku = 1,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Bool_Variable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public ENewEnum12_id_kxje8bmu _NewEnum12_id_kxje8bmu;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Bool_Variable_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Entity_Handle_List = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _IsIlluminatedGameVar = new();
        [FieldAttr(nst: 112, ctr: 104)] public int _Int;
    }
}
