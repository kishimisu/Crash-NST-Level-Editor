namespace Alchemy
{
    // VSC object extracted from: common_Path_Platform_FadeOut_Teleport.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_Bonus_Path_Platform_Start_FadeOutData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public igHandleMetaField _Spline_Event = new();
        [FieldAttr(56)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(64)] public float _Float;
        [FieldAttr(68)] public igVec3fMetaField _Vec_3F = new();
    }
}
