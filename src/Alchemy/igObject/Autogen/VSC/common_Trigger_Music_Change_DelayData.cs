namespace Alchemy
{
    // VSC object extracted from: common_Trigger_Music_Change_Delay.igz

    [ObjectAttr(56, metaType: typeof(CVscComponentData))]
    public class common_Trigger_Music_Change_DelayData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Game_Sound_Music_Settings = new();
        [FieldAttr(48)] public float _Float;
    }
}
