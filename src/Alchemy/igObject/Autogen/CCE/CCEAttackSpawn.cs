namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCEAttackSpawn : CCombatNodeEvent
    {
        [FieldAttr(80)] public CProjectileSpawnData? _spawnData;
        [FieldAttr(88)] public CPhysicalEntityData? _entityData;
    }
}
