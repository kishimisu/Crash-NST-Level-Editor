namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class WranglerFire_Axe_DOTData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _DotDamageData = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _DotRemovedDamageData = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _EntityMessageVariable_id_vx3bour1_variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _DotDuration;
        [FieldAttr(nst: 68, ctr: 60)] public float _DotInterval;
    }
}
