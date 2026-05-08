namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_BonusRoundManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _BonusRoundActive = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_Tag_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_Tag_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_Tag_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _EntityTagVariable_id_zak9a186_variable = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _EntityTagVariable_id_jp8n1zvm_variable = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _EntityTagVariable_id_k7diogjk_variable = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Game_Int_Variable_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Game_Int_Variable_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Game_Int_Variable_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Component_Data = new();
    }
}
