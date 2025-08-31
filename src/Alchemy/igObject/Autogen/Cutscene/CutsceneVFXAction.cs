namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CutsceneVFXAction : CCutsceneAction
    {
        [FieldAttr(24)] public igHandleMetaField _boltOwner = new();
        [FieldAttr(32)] public string? _spawnedEffectName = null;
    }
}
