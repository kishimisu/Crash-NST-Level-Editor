namespace Alchemy
{
    [ObjectAttr(400, 16)]
    public class CBlendedDecalMaterial : igFxMaterial
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
        }

        [ObjectAttr(4)]
        public class BlendChannelsBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _blendDiffuse;
            [FieldAttr(1, size: 1)] public bool _blendNormal;
            [FieldAttr(2, size: 1)] public bool _blendGloss;
            [FieldAttr(3, size: 1)] public bool _blendMetal;
            [FieldAttr(4, size: 1)] public bool _blendEmissive;
        }

        [FieldAttr(120)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(128)] public string? _textureName_diffuse = null;
        [FieldAttr(136)] public string? _textureName_normal = null;
        [FieldAttr(144)] public string? _textureName_gloss = null;
        [FieldAttr(152)] public string? _textureName_metal = null;
        [FieldAttr(160)] public string? _textureName_emissive = null;
        [FieldAttr(168)] public string? _textureName_height = null;
        [FieldAttr(176)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(240)] public igVec4fMetaField _color = new();
        [FieldAttr(256)] public float _normalMapScale = 1.0f;
        [FieldAttr(260)] public bool _parallaxMapping;
        [FieldAttr(264)] public igVec2fMetaField _numSteps = new();
        [FieldAttr(272)] public float _parallaxStrength = 0.02f;
        [FieldAttr(276)] public bool _useVertAlphaAsHeight = true;
        [FieldAttr(277)] public bool _useVertColorAsHeight;
        [FieldAttr(278)] public bool _flipVertAlphaHeight;
        [FieldAttr(288)] public igVec4fMetaField _parallaxParams = new();
        [FieldAttr(304)] public BlendChannelsBitfield _blendChannelsBitfield = new();
        [FieldAttr(308)] public bool _alphaThreshold;
        [FieldAttr(312)] public float _thresholdBlend = 0.05f;
        [FieldAttr(316)] public float _thresholdBias;
        [FieldAttr(320)] public bool _useAlpha = true;
        [FieldAttr(321)] public bool _invertAlpha;
        [FieldAttr(322)] public bool _applyWaterSimulationNormals;
        [FieldAttr(324)] public float _thresholdBlendInverse;
        [FieldAttr(328)] public bool _directionalBlend;
        [FieldAttr(329)] public bool _invertDirectionalBlend;
        [FieldAttr(332)] public igVec2fMetaField _directionalBlendRange = new();
        [FieldAttr(340)] public igVec2fMetaField _directionalBlendAngles = new();
        [FieldAttr(352)] public igVec4fMetaField _directionalBlendParams = new();
        [FieldAttr(368)] public igVec4fMetaField _directionalBlendDirection = new();
        [FieldAttr(384)] public igVec4fMetaField _alphaParams = new();
    }
}
