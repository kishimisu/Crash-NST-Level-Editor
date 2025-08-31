namespace Alchemy
{
    [ObjectAttr(240, 8)]
    public class igSpriteManager : igObject
    {
        [FieldAttr(16)] public string? _defaultModelClass = "hud";
        [FieldAttr(24)] public igObjectPool? _spritePool;
        [FieldAttr(32)] public igObjectPool? _bucketPool;
        [FieldAttr(40)] public igVectorMetaField<igSpriteBucket> _buckets = new();
        [FieldAttr(64)] public igSpriteDrawCallPool? _drawCallPool;
        [FieldAttr(72)] public u16 _defaultCommonState;
        [FieldAttr(74)] public u16 _forceBlendCommonState;
        [FieldAttr(76)] public u16 _useMaterialBlendCommonState;
        [FieldAttr(80)] public igSizeTypeMetaField _repeatLinearSampler = new();
        [FieldAttr(88)] public igSizeTypeMetaField _repeatMipmapSampler = new();
        [FieldAttr(96)] public igSizeTypeMetaField _clampLinearSampler = new();
        [FieldAttr(104)] public igSizeTypeMetaField _clampMipmapSampler = new();
        [FieldAttr(112)] public igGfxShaderConstantList? _textureVertexShaderConstants;
        [FieldAttr(120)] public igSizeTypeMetaField _texturePixelShader = new();
        [FieldAttr(128)] public igSizeTypeMetaField _textureVertexShader = new();
        [FieldAttr(136)] public igGraphicsEffect? _textureEffect;
        [FieldAttr(144)] public igGfxShaderConstantList? _colorVertexShaderConstants;
        [FieldAttr(152)] public igSizeTypeMetaField _colorPixelShader = new();
        [FieldAttr(160)] public igSizeTypeMetaField _colorVertexShader = new();
        [FieldAttr(168)] public igGraphicsEffect? _colorEffect;
        [FieldAttr(176)] public igProcGeometryBuilder? _nonTexturedPgb;
        [FieldAttr(184)] public igProcGeometryBuilder? _texturedPgb;
        [FieldAttr(192)] public igProcGeometryBuilder? _textured2UvPgb;
        [FieldAttr(200, false)] public igRenderer? _renderer;
        [FieldAttr(208)] public igMutex? _lock;
        [FieldAttr(216)] public igVec2fMetaField _windowMin = new();
        [FieldAttr(224)] public igVec2fMetaField _windowMax = new();
        [FieldAttr(232)] public bool _toolViewerIsRunning;
    }
}
