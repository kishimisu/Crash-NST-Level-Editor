namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CPixelCostAverageRenderPass : igRenderPass
    {
        [FieldAttr(56)] public igHandleMetaField _inputRenderTarget = new();
        [FieldAttr(64)] public igHandleMetaField _outputData = new();
        [FieldAttr(72)] public igRawRefMetaField[] _scratchTexture = new igRawRefMetaField[3];
        [FieldAttr(96)] public bool _initialized;
        [FieldAttr(100)] public int _writeIndex;
        [FieldAttr(104)] public int _readIndex = 2;
        [FieldAttr(112)] public igSortKeyCommandDelegateObject? _passDelegate;
    }
}
