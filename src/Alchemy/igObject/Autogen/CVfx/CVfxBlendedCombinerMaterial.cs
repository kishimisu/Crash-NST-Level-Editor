namespace Alchemy
{
    [ObjectAttr(624, 16)]
    public class CVfxBlendedCombinerMaterial : CVfxBlendedMaterial
    {
        [FieldAttr(480)] public float _diffuseColorScale;
        [FieldAttr(484)] public CVfxBlendedMaterial.EBlendFormat _diffuseColorMaskAlpha = CVfxBlendedMaterial.EBlendFormat.kFormatOne;
        [FieldAttr(488)] public float _diffuseAlphaScale;
        [FieldAttr(492)] public float _maskColorScale;
        [FieldAttr(496)] public CVfxBlendedMaterial.EBlendFormat _maskColorMaskAlpha = CVfxBlendedMaterial.EBlendFormat.kFormatOne;
        [FieldAttr(500)] public float _maskAlphaScale;
        [FieldAttr(504)] public float _productColorScale = 1.0f;
        [FieldAttr(508)] public float _productAlphaScale = 1.0f;
        [FieldAttr(512)] public float _finalColorOffset;
        [FieldAttr(516)] public float _finalAlphaOffset;
        [FieldAttr(528)] public igVec4fMetaField _diffuseScale = new();
        [FieldAttr(544)] public igVec4fMetaField _maskScale = new();
        [FieldAttr(560)] public igVec4fMetaField _productScale = new();
        [FieldAttr(576)] public igVec4fMetaField _finalOffset = new();
        [FieldAttr(592)] public bool _doAdd;
        [FieldAttr(593)] public bool _doMul;
        [FieldAttr(594)] public bool _calcAlpha;
        [FieldAttr(608)] public igVec4fMetaField _alphaParams = new();
    }
}
