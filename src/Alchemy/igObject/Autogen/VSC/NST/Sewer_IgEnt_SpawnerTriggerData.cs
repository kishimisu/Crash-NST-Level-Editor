namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Sewer_IgEnt_SpawnerTriggerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int;
        [FieldAttr(nst: 44, ctr: 36)] public float _DelayBetweenActiavations;
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _igEntity_List = new();
    }
}
