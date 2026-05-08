namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_EndRaceRandomCamera_OnKartData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Fade_In_Preset_Data = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Int_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Havok_Linear_Cast_Query_Parameters = new();
    }
}
