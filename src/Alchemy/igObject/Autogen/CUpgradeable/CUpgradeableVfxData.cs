namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CUpgradeableVfxData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _effect = new();
        [FieldAttr(24)] public CVfxSpawnLayers? _spawnLayers;
    }
}
