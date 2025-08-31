namespace Alchemy
{
    // VSC object extracted from: BruiserUndead_LifeSteal_c.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_LifeStealData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _LifeStealStates = new();
        [FieldAttr(48)] public igHandleMetaField _ComponentDataVariable_id_5lrdvhzk_variable = new();
        [FieldAttr(56)] public igHandleMetaField _ComponentDataVariable_id_fm49x7je_variable = new();
        [FieldAttr(64)] public igHandleMetaField _LifestealDebuffData = new();
        [FieldAttr(72)] public float _BonusHealScalar;
        [FieldAttr(76)] public float _RegularHealScalar;
        [FieldAttr(80)] public float _HealDelay;
        [FieldAttr(88)] public igHandleMetaField _FindTargets = new();
    }
}
