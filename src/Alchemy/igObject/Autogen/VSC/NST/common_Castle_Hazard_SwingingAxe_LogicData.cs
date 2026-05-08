namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Castle_Hazard_SwingingAxe_LogicData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _ConstantDelay;
        [FieldAttr(nst: 44, ctr: 36)] public float _StartDelay;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _SwingingAxeSound = new();
    }
}
