namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igRenderPassManager : igObject
    {
        [FieldAttr(16)] public int _backBufferWidth;
        [FieldAttr(20)] public int _backBufferHeight;
        [FieldAttr(24)] public igRenderPassList? _passes;
        [FieldAttr(32)] public igRenderTargetMemPolicy? _renderTargetTexturePolicy;
        [FieldAttr(40)] public igRenderTargetMemPolicy? _renderTargetSurfacePolicy;
        [FieldAttr(48)] public bool _rebuildNeeded;
        [FieldAttr(49)] public bool _active;
        [FieldAttr(50)] public bool _retainCachedScene;
        [FieldAttr(52)] public int _renderTargetTotalSize;
        [FieldAttr(56)] public int _renderTargetMemoryAllocated;
    }
}
