namespace Alchemy
{
    [ObjectAttr(nst: 136, ctr: 128, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BonusRoundTeleporterData : CVscComponentData
    {
        public enum ENewEnum2_id_9tewcwq5
        {
            Generic = 0,
            Tawna = 1,
            Brio = 2,
            Cortex = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public ENewEnum2_id_9tewcwq5 _NewEnum2_id_9tewcwq5;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Fx_Material_Redirect_Table_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Bool_Variable_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Game_Int_Variable_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Int_Variable_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Game_Int_Variable_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Game_Bool_Variable_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Fx_Material_Redirect_Table_0x80 = new();
    }
}
