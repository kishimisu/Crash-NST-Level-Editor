namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class igTextBucket : igObject
    {
        [FieldAttr(16)] public float _depth;
        [FieldAttr(24)] public igFont? _font;
        [FieldAttr(32)] public igScissorNode? _scissor;
        [FieldAttr(40)] public igHandleMetaField _material = new();
        [FieldAttr(48)] public igHandleMetaField _shadowMaterial = new();
        [FieldAttr(56)] public float _shadowDepthOffset;
        [FieldAttr(60)] public bool _hasValidPassId;
        [FieldAttr(61)] public u8 _passId;
        [FieldAttr(64)] public string? _modelClass = null;
        [FieldAttr(72)] public igBitmapFont? _bitmapFont;
        [FieldAttr(80)] public igAttrList? _renderAttrs;
        [FieldAttr(88)] public igGroup? _renderNode;
        [FieldAttr(96)] public igTextureBindAttr2? _textureBindAttr;
        [FieldAttr(104)] public igRawRefMetaField _renderMatrix = new();
        [FieldAttr(112)] public igGroup? _root;
        [FieldAttr(120)] public int _textCount;
        [FieldAttr(124)] public int _vertexCount;
        [FieldAttr(128)] public int _shadowVertexCount;
        [FieldAttr(136, false)] public igText? _firstText;
        [FieldAttr(144, false)] public igRenderer? _renderer;
    }
}
