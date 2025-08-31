namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGuiEventEffectSpawned : igGuiEvent
    {
        [FieldAttr(24)] public igVfxSpawnedEffect? _spawnedEffect;
    }
}
