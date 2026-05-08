namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_Slapshot_DebuffData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Duration;
        [FieldAttr(nst: 44, ctr: 36)] public float _MinTimeScale;
        [FieldAttr(nst: 48, ctr: 40)] public float _MaxTimeScale;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DebuffVfx = new();
    }
}
