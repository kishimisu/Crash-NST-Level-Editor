namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_Lifesteal_DebuffData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _TetherAttackerBolt = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _TetherVictimBolt = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DMG_Lifesteal_End_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _DMG_LifeSteal_Data = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _MaxDistance;
        [FieldAttr(nst: 76, ctr: 68)] public int _DamageScalar;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _TetherVfx = new();
    }
}
