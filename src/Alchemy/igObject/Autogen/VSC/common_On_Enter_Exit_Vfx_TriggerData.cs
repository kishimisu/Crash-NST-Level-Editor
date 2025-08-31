namespace Alchemy
{
    // VSC object extracted from: common_On_Enter_Exit_Vfx_Trigger.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_On_Enter_Exit_Vfx_TriggerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public float _Float;
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point = new();
    }
}
