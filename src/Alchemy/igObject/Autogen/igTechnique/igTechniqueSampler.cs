namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igTechniqueSampler : igNamedObject
    {
        [FieldAttr(24)] public int _unitID;
        [FieldAttr(28)] public EIG_GFX_TEXTURE_FILTER _magFilter;
        [FieldAttr(32)] public EIG_GFX_TEXTURE_FILTER _minFilter;
        [FieldAttr(36)] public EIG_GFX_TEXTURE_WRAP _wrapS = EIG_GFX_TEXTURE_WRAP.REPEAT;
        [FieldAttr(40)] public EIG_GFX_TEXTURE_WRAP _wrapT = EIG_GFX_TEXTURE_WRAP.REPEAT;
        [FieldAttr(44)] public uint _formatHint;
        [FieldAttr(48)] public bool _vertexSampler;
        [FieldAttr(49)] public bool _useMaterialSamplerState;
        [FieldAttr(50)] public bool _useMaterialSamplerWrap;
    }
}
