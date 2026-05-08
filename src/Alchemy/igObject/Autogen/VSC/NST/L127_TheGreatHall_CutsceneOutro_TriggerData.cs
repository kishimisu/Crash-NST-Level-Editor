namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class L127_TheGreatHall_CutsceneOutro_TriggerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Float_Variable = new();
    }
}
