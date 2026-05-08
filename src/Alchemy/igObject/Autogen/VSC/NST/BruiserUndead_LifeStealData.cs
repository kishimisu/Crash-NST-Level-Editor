namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_LifeStealData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _LifeStealStates = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ComponentDataVariable_id_5lrdvhzk_variable = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _ComponentDataVariable_id_fm49x7je_variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _LifestealDebuffData = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _BonusHealScalar;
        [FieldAttr(nst: 76, ctr: 68)] public float _RegularHealScalar;
        [FieldAttr(nst: 80, ctr: 72)] public float _HealDelay;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _FindTargets = new();
    }
}
