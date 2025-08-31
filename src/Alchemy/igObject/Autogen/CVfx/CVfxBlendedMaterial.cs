namespace Alchemy
{
    [ObjectAttr(480, 16)]
    public class CVfxBlendedMaterial : igFxMaterial
    {
        public enum EBlendFunction : uint
        {
            kBlendAdd = 0,
            kBlendMultiply = 1,
            kBlendAddMultiply = 2,
            kBlendMultiplyAdd = 3,
            kBlendThreshold = 4,
            kBlendValue = 5,
        }

        public enum EBlendMode : uint
        {
            kDiffuseColor = 0,
            kMaskColor = 1,
            kVertHue = 2,
            kVertColor = 3,
            kDiffuseAlpha = 4,
            kMaskAlpha = 5,
            kVertValue = 6,
            kVertAlpha = 7,
            kZero = 8,
            kOne = 9,
        }

        public enum EBlendFormat : uint
        {
            kFormatNormal = 0,
            kFormatInvert = 1,
            kFormatSigned = 2,
            kFormatInvertDouble = 3,
            kFormatInvertSigned = 4,
            kFormatDouble = 5,
            kFormatBottomHalf = 6,
            kFormatInvertTopHalf = 7,
            kFormatTopHalf = 8,
            kFormatInvertBottomHalf = 9,
            kFormatNegative = 10,
            kFormatNegativeHalf = 11,
            kFormatNegativeDouble = 12,
            kFormatOne = 13,
            kFormatZero = 14,
        }

        [ObjectAttr(4)]
        public class VfxBlendedMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isSoftParticle;
            [FieldAttr(1, size: 1)] public bool _enableHaze = false;
            [FieldAttr(2, size: 1)] public bool _additive;
            [FieldAttr(3, size: 1)] public bool _premultiplied;
            [FieldAttr(4, size: 1)] public bool _textureCompression_diffuse = false;
            [FieldAttr(5, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(6, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(7, size: 1)] public bool _textureCompression_mask = false;
            [FieldAttr(8, size: 1)] public bool _textureMips_mask = false;
            [FieldAttr(9, size: 1)] public bool _textureAllowDownsample_mask = false;
        }

        [FieldAttr(120)] public u8 _bfStorage__0;
        [FieldAttr(124)] public VfxBlendedMaterialBitfield _vfxBlendedMaterialBitfield = new();
        [FieldAttr(128)] public float _sortDepthOffset;
        [FieldAttr(132)] public float _particleSoftness = 14.0f;
        [FieldAttr(144)] public igMatrix44fMetaField _textureMatrix = new();
        [FieldAttr(208)] public string? _textureName_diffuse = "textures";
        [FieldAttr(224)] public igMatrix44fMetaField _textureMatrix2 = new();
        [FieldAttr(288)] public string? _textureName_mask = "textures";
        [FieldAttr(296)] public EBlendFunction _blendFunction;
        [FieldAttr(300)] public EBlendMode _diffuseColorBlendFactor = CVfxBlendedMaterial.EBlendMode.kOne;
        [FieldAttr(304)] public EBlendFormat _diffuseColorBlendFormat;
        [FieldAttr(308)] public EBlendMode _maskColorBlendFactor = CVfxBlendedMaterial.EBlendMode.kZero;
        [FieldAttr(312)] public EBlendFormat _maskColorBlendFormat;
        [FieldAttr(316)] public EBlendMode _diffuseAlphaBlendFactor = CVfxBlendedMaterial.EBlendMode.kDiffuseAlpha;
        [FieldAttr(320)] public EBlendFormat _diffuseAlphaBlendFormat;
        [FieldAttr(324)] public EBlendMode _maskAlphaBlendFactor = CVfxBlendedMaterial.EBlendMode.kZero;
        [FieldAttr(328)] public EBlendFormat _maskAlphaBlendFormat;
        [FieldAttr(332)] public bool _preColor = true;
        [FieldAttr(333)] public bool _preHue;
        [FieldAttr(334)] public bool _generateMaskAlpha;
        [FieldAttr(336)] public float _thresholdBlend = 0.05f;
        [FieldAttr(340)] public float _thresholdBias;
        [FieldAttr(344)] public EBlendMode _thresholdDiffuseAlphaBlendFactor = CVfxBlendedMaterial.EBlendMode.kDiffuseAlpha;
        [FieldAttr(348)] public EBlendFormat _thresholdDiffuseAlphaBlendFormat;
        [FieldAttr(352)] public EBlendMode _thresholdMaskAlphaBlendFactor = CVfxBlendedMaterial.EBlendMode.kZero;
        [FieldAttr(356)] public EBlendFormat _thresholdMaskAlphaBlendFormat;
        [FieldAttr(360)] public float _thresholdBlendInverse;
        [FieldAttr(364)] public float _particleSoftnessInverse;
        [FieldAttr(368)] public igVec4fMetaField _diffuseColorBlendParams = new();
        [FieldAttr(384)] public igVec4fMetaField _diffuseAlphaBlendParams = new();
        [FieldAttr(400)] public igVec4fMetaField _maskColorBlendParams = new();
        [FieldAttr(416)] public igVec4fMetaField _maskAlphaBlendParams = new();
        [FieldAttr(432)] public igVec4fMetaField _thresholdDiffuseAlphaBlendParams = new();
        [FieldAttr(448)] public igVec4fMetaField _thresholdMaskAlphaBlendParams = new();
        [FieldAttr(464)] public bool _blendMode0;
        [FieldAttr(465)] public bool _blendMode1;
        [FieldAttr(466)] public bool _multiplyColor;
        [FieldAttr(467)] public bool _multiplyAlpha;
    }
}
