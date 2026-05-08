namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class CrateMesseger_TriggerScriptData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SpawnerActivationList = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _DelayBetweenActiavations;
    }
}
