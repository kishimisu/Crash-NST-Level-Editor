namespace Alchemy
{
    [ObjectAttr(200, 8)]
    public class igRenderTarget : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _parentTarget = new();
        [FieldAttr(24)] public bool _renderToParentTexture;
        [FieldAttr(28)] public int _renderToParentTextureLevel;
        [FieldAttr(32)] public string? _formatName = null;
        [FieldAttr(40)] public bool _createTexture = true;
        [FieldAttr(41)] public bool _isColorSurface = true;
        [FieldAttr(42)] public bool _forceExpandInPlace;
        [FieldAttr(48)] public string? _textureFormatName = null;
        [FieldAttr(56)] public int _width = -1;
        [FieldAttr(60)] public int _height = -1;
        [FieldAttr(64)] public float _widthScale = 1.0f;
        [FieldAttr(68)] public float _heightScale = 1.0f;
        [FieldAttr(72)] public float _highResolutionScale = 1.0f;
        [FieldAttr(76)] public EIG_GFX_MULTISAMPLE_TYPE _msaaType;
        [FieldAttr(80)] public int _levelCount = 1;
        [FieldAttr(84)] public uint _wiiClearOnResolve;
        [FieldAttr(88)] public bool _wiiDownsample2x2;
        [FieldAttr(89)] public bool _ps4UseHtile = true;
        [FieldAttr(90)] public bool _ps4UseCompression = true;
        [FieldAttr(91)] public bool _ps4UseCheckerboard;
        [FieldAttr(92)] public bool _mobileClearToAnyValue;
        [FieldAttr(93)] public bool _mobileDiscardAfterUse;
        [FieldAttr(94)] public bool _active;
        [FieldAttr(96)] public int _computedWidth;
        [FieldAttr(100)] public int _computedHeight;
        [FieldAttr(104)] public string? _computedFormatName = null;
        [FieldAttr(112)] public string? _computedTextureFormatName = null;
        [FieldAttr(120)] public int _firstWrite = -1;
        [FieldAttr(124)] public int _lastWrite = -1;
        [FieldAttr(128)] public int _firstRead = -1;
        [FieldAttr(132)] public int _lastRead = -1;
        [FieldAttr(136)] public int _firstUse = -1;
        [FieldAttr(140)] public int _lastUse = -1;
        [FieldAttr(144)] public bool _global;
        [FieldAttr(152)] public igRawRefMetaField _textureBuffer = new();
        [FieldAttr(160)] public int _wiiEfbX;
        [FieldAttr(164)] public int _wiiEfbY;
        [FieldAttr(168)] public igSizeTypeMetaField _texture = new();
        [FieldAttr(176)] public igSizeTypeMetaField _renderTargetView = new();
        [FieldAttr(184)] public bool _durangoInEsram;
        [FieldAttr(188)] public uint _durangoEsramOffset;
        [FieldAttr(192)] public igRenderTarget? _resolveTarget;
    }
}
