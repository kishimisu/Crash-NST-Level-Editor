namespace Alchemy
{
    // VSC object extracted from: BruiserUndead_Lifesteal_Debuff_c.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class BruiserUndead_Lifesteal_DebuffData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _TetherAttackerBolt = new();
        [FieldAttr(48)] public igHandleMetaField _TetherVictimBolt = new();
        [FieldAttr(56)] public igHandleMetaField _DMG_Lifesteal_End_Data = new();
        [FieldAttr(64)] public igHandleMetaField _DMG_LifeSteal_Data = new();
        [FieldAttr(72)] public float _MaxDistance;
        [FieldAttr(76)] public int _DamageScalar;
        [FieldAttr(80)] public igHandleMetaField _TetherVfx = new();
    }
}
