namespace Alchemy
{
    // VSC object extracted from: BruiserUndead_Slapshot_Debuff_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_Slapshot_DebuffData : CVscComponentData
    {
        [FieldAttr(40)] public float _Duration;
        [FieldAttr(44)] public float _MinTimeScale;
        [FieldAttr(48)] public float _MaxTimeScale;
        [FieldAttr(56)] public igHandleMetaField _DebuffVfx = new();
    }
}
