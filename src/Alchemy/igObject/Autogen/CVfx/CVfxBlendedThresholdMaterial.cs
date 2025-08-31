namespace Alchemy
{
    [ObjectAttr(832, 16)]
    public class CVfxBlendedThresholdMaterial : CVfxBlendedCombinerMaterial
    {
        [FieldAttr(624)] public CVfxBlendedMaterial.EBlendFormat _thresholdDiffuseFactor;
        [FieldAttr(628)] public float _thresholdDiffuseScale = 1.0f;
        [FieldAttr(632)] public CVfxBlendedMaterial.EBlendFormat _thresholdMaskFactor;
        [FieldAttr(636)] public float _thresholdMaskScale = 1.0f;
        [FieldAttr(640)] public float _thresholdProductScale;
        [FieldAttr(644)] public float _thresholdFactor = 1.0f;
        [FieldAttr(648)] public float _thresholdOffset;
        [FieldAttr(652)] public float _diffuseColorScale2;
        [FieldAttr(656)] public CVfxBlendedMaterial.EBlendFormat _diffuseColorMaskAlpha2 = CVfxBlendedMaterial.EBlendFormat.kFormatOne;
        [FieldAttr(660)] public float _diffuseAlphaScale2;
        [FieldAttr(664)] public float _maskColorScale2;
        [FieldAttr(668)] public CVfxBlendedMaterial.EBlendFormat _maskColorMaskAlpha2 = CVfxBlendedMaterial.EBlendFormat.kFormatOne;
        [FieldAttr(672)] public float _maskAlphaScale2;
        [FieldAttr(676)] public float _productColorScale2 = 1.0f;
        [FieldAttr(680)] public float _productAlphaScale2 = 1.0f;
        [FieldAttr(684)] public float _finalColorOffset2;
        [FieldAttr(688)] public float _finalAlphaOffset2;
        [FieldAttr(704)] public igVec4fMetaField _diffuseScale2 = new();
        [FieldAttr(720)] public igVec4fMetaField _maskScale2 = new();
        [FieldAttr(736)] public igVec4fMetaField _productScale2 = new();
        [FieldAttr(752)] public igVec4fMetaField _finalOffset2 = new();
        [FieldAttr(768)] public igVec4fMetaField _alphaParams2 = new();
        [FieldAttr(784)] public igVec4fMetaField _thresholdParams = new();
        [FieldAttr(800)] public igVec4fMetaField _thresholdParams2 = new();
        [FieldAttr(816)] public igVec4fMetaField _thresholdParams3 = new();
    }
}
