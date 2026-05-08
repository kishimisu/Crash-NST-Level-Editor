namespace Alchemy
{
    [ObjectAttr(nst: 152, ctr: 144, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Race_Start_Event_ChainData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Cutscene_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Edc_Info_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Fade_Out_Preset_Data_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Fade_In_Preset_Data_0x48 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_Handle_List = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Fade_In_Preset_Data_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Fade_Out_Preset_Data_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Component_Data = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Vfx_Effect_0x78 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Edc_Info_0x80 = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Vfx_Effect_0x88 = new();
    }
}
