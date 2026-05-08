namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_Slapshot_ProjectileData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _BehaviorStateVariable_id_dfmaa3iy_variable = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _BehaviorStateVariable_id_dtz8064q_variable = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DebuffData = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _ComponentDataVariable_id_npfmnbd5_variable = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _ChargeMaxDuration;
        [FieldAttr(nst: 76, ctr: 68)] public float _DamageMax;
    }
}
