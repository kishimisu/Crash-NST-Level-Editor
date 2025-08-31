namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igImageInputData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _image = new();
        [FieldAttr(24)] public int _unitID;
        [FieldAttr(28)] public EIG_GFX_TEXTURE_FILTER _magFilter;
        [FieldAttr(32)] public EIG_GFX_TEXTURE_FILTER _minFilter;
        [FieldAttr(36)] public EIG_GFX_TEXTURE_WRAP _wrapS;
        [FieldAttr(40)] public EIG_GFX_TEXTURE_WRAP _wrapT;
        [FieldAttr(44)] public EIG_GFX_TEXTURE_WRAP _wrapR;
        [FieldAttr(48)] public igSizeTypeMetaField _sampler = new();
    }
}
