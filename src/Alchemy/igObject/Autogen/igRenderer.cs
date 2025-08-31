namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class igRenderer : igObject
    {
        [FieldAttr(16)] public igDebugGeometryManager? _debugGeometry;
        [FieldAttr(24)] public igRenderPassManager? _passManager;
        [FieldAttr(32)] public igSpriteManager? _spriteManager;
        [FieldAttr(40)] public igTextManager? _textManager;
        [FieldAttr(48)] public igAtomicSortKeyValueListMetaField _sortKeyList = new();
        [FieldAttr(72)] public igVectorMetaField<igCommandStreamEncoder> _encoders = new();
        [FieldAttr(96)] public igStatHandleMetaField _encodeTimeState = new();
        [FieldAttr(100)] public igStatHandleMetaField _commandStreamMemoryUsageState = new();
        [FieldAttr(104)] public igRawRefMetaField _debugCallback = new();
        [FieldAttr(112)] public igRawRefMetaField _vfxPostUpdateCallback = new();
        [FieldAttr(120)] public bool _lockOnOperation;
        [FieldAttr(121)] public bool _enabled4K;
        [FieldAttr(122)] public bool _active;
        [FieldAttr(128)] public igModelScene? _modelScene;
        [FieldAttr(144)] public int _encodeJobCounter;
    }
}
