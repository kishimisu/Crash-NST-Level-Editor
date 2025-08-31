namespace Alchemy
{
    [ObjectAttr(248, 8)]
    public class igText : igObject
    {
        public enum EColorMode : uint
        {
            kFlatColor = 0,
            kLinearVerticalAToB = 1,
        }

        [FieldAttr(16)] public string? _string = null;
        [FieldAttr(24, false)] public igTextManager? _manager;
        [FieldAttr(32)] public igFont? _font;
        [FieldAttr(40)] public igRawRefMetaField _rasterizer = new();
        [FieldAttr(48)] public igHandleMetaField _material = new();
        [FieldAttr(56)] public igHandleMetaField _shadowMaterial = new();
        [FieldAttr(64)] public igVec2fMetaField _position = new();
        [FieldAttr(72)] public igVec2fMetaField _center = new();
        [FieldAttr(80)] public igVec2fMetaField _scale = new();
        [FieldAttr(88)] public float _rotation;
        [FieldAttr(92)] public igVec4ucMetaField _color = new();
        [FieldAttr(96)] public EColorMode _colorMode;
        [FieldAttr(100)] public igVec4ucMetaField _colorA = new();
        [FieldAttr(104)] public igVec4ucMetaField _colorB = new();
        [FieldAttr(108)] public float _width;
        [FieldAttr(112)] public float _height = 1.0f;
        [FieldAttr(116)] public float _unscaledWidth;
        [FieldAttr(120)] public float _unscaledHeight;
        [FieldAttr(124)] public igFont.EHorizontalAlignment _horizontalAlignment;
        [FieldAttr(128)] public igFont.EVerticalAlignment _verticalAlignment;
        [FieldAttr(132)] public bool _wordWrap;
        [FieldAttr(136)] public float _leading;
        [FieldAttr(140)] public float _tracking;
        [FieldAttr(144)] public bool _clip;
        [FieldAttr(148)] public igVec2fMetaField _clipMin = new();
        [FieldAttr(156)] public igVec2fMetaField _clipMax = new();
        [FieldAttr(164)] public float _depth;
        [FieldAttr(168)] public string? _modelClass = null;
        [FieldAttr(176)] public igAttrList? _renderAttrs;
        [FieldAttr(184)] public igGroup? _renderNode;
        [FieldAttr(192)] public igRawRefMetaField _renderMatrix = new();
        [FieldAttr(200)] public bool _hidden;
        [FieldAttr(201)] public bool _shadow;
        [FieldAttr(204)] public igVec2fMetaField _shadowOffset = new();
        [FieldAttr(212)] public igVec4ucMetaField _shadowColor = new();
        [FieldAttr(216)] public float _shadowDepthOffset;
        [FieldAttr(224, false)] public igTextBucket? _previousBucket;
        [FieldAttr(232, false)] public igText? _nextInBucket;
        [FieldAttr(240)] public int _vertexCount;
    }
}
