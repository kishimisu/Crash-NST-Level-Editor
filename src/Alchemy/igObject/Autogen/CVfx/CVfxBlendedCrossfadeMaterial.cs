namespace Alchemy
{
    [ObjectAttr(768, 16)]
    public class CVfxBlendedCrossfadeMaterial : CVfxBlendedCombinerMaterial
    {
        [FieldAttr(624)] public CVfxBlendedMaterial.EBlendFormat _blendFactor;
        [FieldAttr(628)] public float _diffuseColorScale2;
        [FieldAttr(632)] public CVfxBlendedMaterial.EBlendFormat _diffuseColorMaskAlpha2 = CVfxBlendedMaterial.EBlendFormat.kFormatOne;
        [FieldAttr(636)] public float _diffuseAlphaScale2;
        [FieldAttr(640)] public float _maskColorScale2;
        [FieldAttr(644)] public CVfxBlendedMaterial.EBlendFormat _maskColorMaskAlpha2 = CVfxBlendedMaterial.EBlendFormat.kFormatOne;
        [FieldAttr(648)] public float _maskAlphaScale2;
        [FieldAttr(652)] public float _productColorScale2 = 1.0f;
        [FieldAttr(656)] public float _productAlphaScale2 = 1.0f;
        [FieldAttr(660)] public float _finalColorOffset2;
        [FieldAttr(664)] public float _finalAlphaOffset2;
        [FieldAttr(672)] public igVec4fMetaField _diffuseScale2 = new();
        [FieldAttr(688)] public igVec4fMetaField _maskScale2 = new();
        [FieldAttr(704)] public igVec4fMetaField _productScale2 = new();
        [FieldAttr(720)] public igVec4fMetaField _finalOffset2 = new();
        [FieldAttr(736)] public igVec4fMetaField _alphaParams2 = new();
        [FieldAttr(752)] public igVec4fMetaField _blendParams = new();
    }
}
