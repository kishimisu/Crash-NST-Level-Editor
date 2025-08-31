namespace Alchemy
{
    // VSC object extracted from: Common_Spawner_EnableOrDisable_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Common_Spawner_EnableOrDisableData : CVscComponentData
    {
        [FieldAttr(40)] public bool _EnableOnEnter;
        [FieldAttr(41)] public bool _DisableOnExit;
        [FieldAttr(42)] public bool _DisableOnEnter;
        [FieldAttr(43)] public bool _EnableOnExit;
        [FieldAttr(48)] public igHandleMetaField _TriggerVolume = new();
        [FieldAttr(56)] public float _Initial_Delay_On_Enter;
        [FieldAttr(60)] public bool _Bool;
    }
}
