namespace Alchemy
{
    [ObjectAttr(352, 16)]
    public class CStandardMaterial : igFxMaterial
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
            [FieldAttr(15, size: 1)] public bool _textureCompression_backscatter = false;
            [FieldAttr(16, size: 1)] public bool _textureMips_backscatter = false;
            [FieldAttr(17, size: 1)] public bool _textureAllowDownsample_backscatter = false;
            [FieldAttr(18, size: 1)] public bool _textureCompression_height = false;
            [FieldAttr(19, size: 1)] public bool _textureMips_height = false;
        }

        [FieldAttr(120)] public float _normalMapScale = 1.0f;
        [FieldAttr(124)] public bool _parallaxMapping;
        [FieldAttr(125)] public bool _additive;
        [FieldAttr(128)] public igVec2fMetaField _numSteps = new();
        [FieldAttr(136)] public float _parallaxStrength = 0.02f;
        [FieldAttr(140)] public bool _useVertAlphaAsHeight = true;
        [FieldAttr(141)] public bool _useVertColorAsHeight;
        [FieldAttr(142)] public bool _flipVertAlphaHeight;
        [FieldAttr(143)] public bool _parallaxDepth;
        [FieldAttr(144)] public igVec4fMetaField _parallaxParams = new();
        [FieldAttr(160)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(164)] public bool _hasEmissiveMap = true;
        [FieldAttr(165)] public bool _hasNormalMap = true;
        [FieldAttr(166)] public bool _mobileUseNormalMap = true;
        [FieldAttr(168)] public string? _textureName_diffuse = null;
        [FieldAttr(176)] public string? _textureName_normal = null;
        [FieldAttr(184)] public string? _textureName_gloss = null;
        [FieldAttr(192)] public string? _textureName_metal = null;
        [FieldAttr(200)] public string? _textureName_emissive = null;
        [FieldAttr(208)] public string? _textureName_backscatter = null;
        [FieldAttr(216)] public string? _textureName_height = null;
        [FieldAttr(224)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(288)] public igVec4fMetaField _color = new();
        [FieldAttr(304)] public bool _renderObscured;
        [FieldAttr(305)] public bool _onlyRenderObscured;
        [FieldAttr(306)] public bool _anisotropicShading;
        [FieldAttr(307)] public bool _iridescentShading;
        [FieldAttr(308)] public bool _iridescentEnabled;
        [FieldAttr(312)] public CIridescentMaterialFeature? _iridescentProperties;
        [FieldAttr(320)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
        [FieldAttr(328)] public CVertexWibbleMaterialFeature? _vertexWibble;
        [FieldAttr(336)] public bool _vertexWibbleEnabled;
        [FieldAttr(340)] public int _paletteIndex;
        [FieldAttr(344)] public bool _excludeFromDecimation;
        [FieldAttr(345)] public bool _enableReflections;
    }
}
