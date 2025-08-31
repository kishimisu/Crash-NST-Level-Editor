namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVfxPoseSpawnLocationOperator : igVfxLoadOperator
    {
        [FieldAttr(32)] public igVfxSpawnLocationData? _spawnLocation;
        [FieldAttr(40)] public u32 /* igStructMetaField */ _primitive;
    }
}
