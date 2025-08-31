namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CWorldCollectibleModifierItem : igObject
    {
        [FieldAttr(16)] public string? _modelName = null;
        [FieldAttr(24)] public igHandleMetaField _idleVfxHandle = new();
        [FieldAttr(32)] public igHandleMetaField _trailVfxHandle = new();
        [FieldAttr(40)] public igHandleMetaField _collectBeginVfxHandle = new();
        [FieldAttr(48)] public igHandleMetaField _collectEndVfxHandle = new();
    }
}
