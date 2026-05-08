namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Bonus_Path_Platform_Start_FadeOutData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Spline_Event = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float;
        [FieldAttr(nst: 68, ctr: 60)] public igVec3fMetaField _Vec_3F = new();
    }
}
