namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igRenderTargetInputData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _renderTarget = new();
        [FieldAttr(24)] public int _unitID;
        [FieldAttr(28)] public bool _autoBind = true;
        [FieldAttr(32)] public EIG_GFX_TEXTURE_FILTER _magFilter;
        [FieldAttr(36)] public EIG_GFX_TEXTURE_FILTER _minFilter;
        [FieldAttr(40)] public EIG_GFX_TEXTURE_WRAP _wrapS;
        [FieldAttr(44)] public EIG_GFX_TEXTURE_WRAP _wrapT;
        [FieldAttr(48)] public EIG_GFX_MULTISAMPLE_TYPE _msaaType;
        [FieldAttr(52)] public bool _comparisonSampler;
        [FieldAttr(56)] public igSizeTypeMetaField _texture = new();
        [FieldAttr(64)] public igSizeTypeMetaField _sampler = new();
    }
}
