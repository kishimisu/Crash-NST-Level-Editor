namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Common_Spawner_EnableOrDisableData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _EnableOnEnter;
        [FieldAttr(nst: 41, ctr: 33)] public bool _DisableOnExit;
        [FieldAttr(nst: 42, ctr: 34)] public bool _DisableOnEnter;
        [FieldAttr(nst: 43, ctr: 35)] public bool _EnableOnExit;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _TriggerVolume = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Initial_Delay_On_Enter;
        [FieldAttr(nst: 60, ctr: 52)] public bool _Bool;
    }
}
