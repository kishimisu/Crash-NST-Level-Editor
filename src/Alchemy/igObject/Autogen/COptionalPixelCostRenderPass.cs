namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class COptionalPixelCostRenderPass : igRenderPass
    {
        [FieldAttr(56)] public igHandleMetaField _enabledData = new();
        [FieldAttr(64)] public uint _mode;
        [FieldAttr(68)] public bool _ignoreMode;
    }
}
