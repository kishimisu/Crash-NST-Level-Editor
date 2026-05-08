namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Trigger_Music_Change_DelayData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Sound_Music_Settings = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
    }
}
