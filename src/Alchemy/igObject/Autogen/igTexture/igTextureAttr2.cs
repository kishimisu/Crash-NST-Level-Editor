namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class igTextureAttr2 : igVisualAttribute
    {
        [FieldAttr(24)] public uint _formatHint;
        [FieldAttr(28)] public bool _loadInVramForCtr;
        [FieldAttr(32)] public EIG_GFX_TEXTURE_FILTER _magFilter;
        [FieldAttr(36)] public EIG_GFX_TEXTURE_FILTER _minFilter;
        [FieldAttr(40)] public EIG_GFX_TEXTURE_WRAP _wrapS = EIG_GFX_TEXTURE_WRAP.REPEAT;
        [FieldAttr(44)] public EIG_GFX_TEXTURE_WRAP _wrapT = EIG_GFX_TEXTURE_WRAP.REPEAT;
        [FieldAttr(48)] public EIG_GFX_MULTISAMPLE_TYPE _msaaType;
        [FieldAttr(52)] public EIG_GFX_TEXTURE_SOURCE _source;
        [FieldAttr(56)] public igImage2? _image;
        [FieldAttr(64)] public igRawRefMetaField _videoBuffer = new();
        [FieldAttr(72)] public int _texHandle = -1;
        [FieldAttr(80)] public igHandleMetaField _imageHandle = new();
        [FieldAttr(88)] public EIG_GFX_TEXTURE_WRAP _wrapR = EIG_GFX_TEXTURE_WRAP.REPEAT;
        [FieldAttr(92)] public bool _filterFixedUp;
    }
}
