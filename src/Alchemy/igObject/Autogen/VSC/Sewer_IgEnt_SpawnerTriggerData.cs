namespace Alchemy
{
    // VSC object extracted from: Sewer_IgEnt_SpawnerTrigger.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Sewer_IgEnt_SpawnerTriggerData : CVscComponentData
    {
        [FieldAttr(40)] public int _Int;
        [FieldAttr(44)] public float _DelayBetweenActiavations;
        [FieldAttr(48)] public bool _Bool;
        [FieldAttr(56)] public igHandleMetaField _igEntity_List = new();
    }
}
