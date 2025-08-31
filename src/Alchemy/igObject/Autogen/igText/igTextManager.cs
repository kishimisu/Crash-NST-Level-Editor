namespace Alchemy
{
    [ObjectAttr(208, 8)]
    public class igTextManager : igObject
    {
        [FieldAttr(16)] public string? _defaultModelClass = "hud";
        [FieldAttr(24)] public igFont? _defaultFont;
        [FieldAttr(32)] public igTextPool? _textPool;
        [FieldAttr(40)] public igVectorMetaField<igText> _textsToDelete = new();
        [FieldAttr(64)] public igTextBucketPool? _bucketPool;
        [FieldAttr(72)] public igVectorMetaField<igTextBucket> _buckets = new();
        [FieldAttr(96)] public igTextDrawCallPool? _drawCallPool;
        [FieldAttr(104)] public igMemoryCommandStream? _defaultState;
        [FieldAttr(112)] public igSizeTypeMetaField _alphaBlending = new();
        [FieldAttr(120)] public igSizeTypeMetaField _depthWriteOff = new();
        [FieldAttr(128)] public igSizeTypeMetaField _backFaceCulling = new();
        [FieldAttr(136)] public igGfxShaderConstantList? _vertexShaderConstants;
        [FieldAttr(144)] public igSizeTypeMetaField _pixelShader = new();
        [FieldAttr(152)] public igSizeTypeMetaField _vertexShader = new();
        [FieldAttr(160)] public igProcGeometryBuilder? _pgb;
        [FieldAttr(168, false)] public igRenderer? _renderer;
        [FieldAttr(176)] public igMutex? _lock;
        [FieldAttr(184)] public igVec2fMetaField _windowMin = new();
        [FieldAttr(192)] public igVec2fMetaField _windowMax = new();
        [FieldAttr(200)] public bool _toolViewerIsRunning;
    }
}
