namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class C1_StartScreen_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Camera_Base_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Camera_Base_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Edc_Info = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Cutscene_Data = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Fade_Sequence_Preset_Data = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 96, ctr: 88)] public float _Float;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Fade_In_Preset_Data = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity = new();
    }
}
