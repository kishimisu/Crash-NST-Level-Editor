namespace Alchemy
{
    [ObjectAttr(560, 16)]
    public class CBlendedMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class TextureBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(3, size: 1)] public bool _textureCompression_normal = false;
            [FieldAttr(4, size: 1)] public bool _textureMips_normal = false;
            [FieldAttr(5, size: 1)] public bool _textureAllowDownsample_normal = false;
            [FieldAttr(6, size: 1)] public bool _textureCompression_gloss = false;
            [FieldAttr(7, size: 1)] public bool _textureMips_gloss = false;
            [FieldAttr(8, size: 1)] public bool _textureAllowDownsample_gloss = false;
            [FieldAttr(9, size: 1)] public bool _textureCompression_metal = false;
            [FieldAttr(10, size: 1)] public bool _textureMips_metal = false;
            [FieldAttr(11, size: 1)] public bool _textureAllowDownsample_metal = false;
            [FieldAttr(12, size: 1)] public bool _textureCompression_emissive = false;
            [FieldAttr(13, size: 1)] public bool _textureMips_emissive = false;
            [FieldAttr(14, size: 1)] public bool _textureAllowDownsample_emissive = false;
            [FieldAttr(15, size: 1)] public bool _textureCompression_height = false;
            [FieldAttr(16, size: 1)] public bool _textureMips_height = false;
            [FieldAttr(17, size: 1)] public bool _textureCompression_diffuse2 = false;
            [FieldAttr(18, size: 1)] public bool _textureMips_diffuse2 = false;
            [FieldAttr(19, size: 1)] public bool _textureAllowDownsample_diffuse2 = false;
            [FieldAttr(20, size: 1)] public bool _textureCompression_normal2 = false;
            [FieldAttr(21, size: 1)] public bool _textureMips_normal2 = false;
            [FieldAttr(22, size: 1)] public bool _textureCompression_gloss2 = false;
            [FieldAttr(23, size: 1)] public bool _textureMips_gloss2 = false;
            [FieldAttr(24, size: 1)] public bool _textureAllowDownsample_gloss2 = false;
            [FieldAttr(25, size: 1)] public bool _textureCompression_metal2 = false;
            [FieldAttr(26, size: 1)] public bool _textureMips_metal2 = false;
            [FieldAttr(27, size: 1)] public bool _textureAllowDownsample_metal2 = false;
            [FieldAttr(28, size: 1)] public bool _textureCompression_emissive2 = false;
            [FieldAttr(29, size: 1)] public bool _textureMips_emissive2 = false;
            [FieldAttr(30, size: 1)] public bool _textureAllowDownsample_emissive2 = false;
        }

        [ObjectAttr(4)]
        public class BlendChannelsBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _blendDiffuse = true;
            [FieldAttr(1, size: 1)] public bool _blendNormal = false;
            [FieldAttr(2, size: 1)] public bool _blendGloss = false;
            [FieldAttr(3, size: 1)] public bool _blendMetal = false;
            [FieldAttr(4, size: 1)] public bool _blendEmissive = false;
        }

        [ObjectAttr(1)]
        public class BfStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureAllowDownsample_normal2 = true;
        }

        [FieldAttr(120)] public float _normalMapScale = 1.0f;
        [FieldAttr(124)] public float _normalMapScale2 = 1.0f;
        [FieldAttr(128)] public bool _parallaxMapping;
        [FieldAttr(129)] public bool _additive;
        [FieldAttr(132)] public igVec2fMetaField _numSteps = new();
        [FieldAttr(140)] public float _parallaxStrength = 0.02f;
        [FieldAttr(144)] public bool _heightMapUsesSecondUvChannel;
        [FieldAttr(145)] public bool _useVertAlphaAsHeight = true;
        [FieldAttr(146)] public bool _useVertColorAsHeight;
        [FieldAttr(147)] public bool _flipVertAlphaHeight;
        [FieldAttr(148)] public bool _parallaxDepth;
        [FieldAttr(149)] public bool _alphaThreshold;
        [FieldAttr(152)] public float _thresholdBlend = 0.05f;
        [FieldAttr(156)] public float _thresholdBias;
        [FieldAttr(160)] public bool _useTopAlpha = true;
        [FieldAttr(161)] public bool _invertTopAlpha;
        [FieldAttr(162)] public bool _useBottomAlpha;
        [FieldAttr(163)] public bool _invertBottomAlpha;
        [FieldAttr(164)] public float _thresholdBlendInverse;
        [FieldAttr(168)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(172)] public bool _directionalBlend;
        [FieldAttr(173)] public bool _invertDirectionalBlend;
        [FieldAttr(176)] public igVec2fMetaField _directionalBlendRange = new();
        [FieldAttr(184)] public igVec2fMetaField _directionalBlendAngles = new();
        [FieldAttr(192)] public igVec4fMetaField _directionalBlendParams = new();
        [FieldAttr(208)] public igVec4fMetaField _directionalBlendDirection = new();
        [FieldAttr(224)] public igVec4fMetaField _alphaParams = new();
        [FieldAttr(240)] public igVec4fMetaField _parallaxParams = new();
        [FieldAttr(256)] public BlendChannelsBitfield _blendChannelsBitfield = new();
        [FieldAttr(272)] public igVec4fMetaField _blendStateParams1 = new();
        [FieldAttr(288)] public igVec4fMetaField _blendStateParams2 = new();
        [FieldAttr(304)] public igMatrix44fMetaField _textureMatrix = new();
        [FieldAttr(368)] public igMatrix44fMetaField _textureMatrix2 = new();
        [FieldAttr(432)] public igVec4fMetaField _color = new();
        [FieldAttr(448)] public string? _textureName_diffuse = null;
        [FieldAttr(456)] public string? _textureName_normal = null;
        [FieldAttr(464)] public string? _textureName_gloss = null;
        [FieldAttr(472)] public string? _textureName_metal = null;
        [FieldAttr(480)] public string? _textureName_emissive = null;
        [FieldAttr(488)] public string? _textureName_height = null;
        [FieldAttr(496)] public string? _textureName_diffuse2 = null;
        [FieldAttr(504)] public string? _textureName_normal2 = null;
        [FieldAttr(512)] public BfStorage _bfStorage__0 = new();
        [FieldAttr(520)] public string? _textureName_gloss2 = null;
        [FieldAttr(528)] public string? _textureName_metal2 = null;
        [FieldAttr(536)] public string? _textureName_emissive2 = null;
        [FieldAttr(544)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
        [FieldAttr(548)] public int _paletteIndex;
        [FieldAttr(552)] public int _paletteIndex2;
    }
}
