namespace Alchemy
{
    // VSC object extracted from: DDA_Section.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class DDA_CheckpointData : CVscComponentData
    {
        public enum ENewEnum12_id_kxje8bmu
        {
            Checkpoint = 0,
            AkuAku = 1,
        }

        [FieldAttr(40)] public igHandleMetaField _Game_Bool_Variable_0x28 = new();
        [FieldAttr(48)] public ENewEnum12_id_kxje8bmu _NewEnum12_id_kxje8bmu;
        [FieldAttr(56)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(64)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Game_Bool_Variable_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Entity_Handle_List = new();
        [FieldAttr(104)] public igHandleMetaField _IsIlluminatedGameVar = new();
        [FieldAttr(112)] public int _Int;
    }
}
