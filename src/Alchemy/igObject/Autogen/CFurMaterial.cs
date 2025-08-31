namespace Alchemy
{
    [ObjectAttr(400, 16)]
    public class CFurMaterial : igFxMaterial
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
            [FieldAttr(20, size: 1)] public bool _textureCompression_fiber;
            [FieldAttr(21, size: 1)] public bool _textureMips_fiber = false;
        }

        [FieldAttr(120)] public float _normalMapScale = 1.0f;
        [FieldAttr(124)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(128)] public bool _hasEmissiveMap = true;
        [FieldAttr(129)] public bool _hasNormalMap = true;
        [FieldAttr(136)] public string? _textureName_diffuse = null;
        [FieldAttr(144)] public string? _textureName_normal = null;
        [FieldAttr(152)] public string? _textureName_gloss = null;
        [FieldAttr(160)] public string? _textureName_metal = null;
        [FieldAttr(168)] public string? _textureName_emissive = null;
        [FieldAttr(176)] public string? _textureName_backscatter = null;
        [FieldAttr(184)] public string? _textureName_height = null;
        [FieldAttr(192)] public string? _textureName_fiber = null;
        [FieldAttr(208)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(272)] public igVec4fMetaField _color = new();
        [FieldAttr(288)] public bool _renderObscured;
        [FieldAttr(289)] public bool _onlyRenderObscured;
        [FieldAttr(292)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
        [FieldAttr(296)] public float _shellMinThickness;
        [FieldAttr(300)] public float _shellThickness = 4.0f;
        [FieldAttr(304)] public int _shellCount = 4;
        [FieldAttr(308)] public float _fiberDensity = 1.0f;
        [FieldAttr(312)] public float _fiberAspectRatio = 1.0f;
        [FieldAttr(320)] public igVec4fMetaField _fiberDistribution = new();
        [FieldAttr(336)] public float _fiberRadius = 1.0f;
        [FieldAttr(340)] public float _furSoftness;
        [FieldAttr(344)] public float _fiberFlex = 25.0f;
        [FieldAttr(348)] public float _fiberProfile;
        [FieldAttr(352)] public float _maxFiberDarkening = 0.25f;
        [FieldAttr(356)] public float _furHighlightBaseWidth = 0.6f;
        [FieldAttr(360)] public float _furHighlightMapWidth = 0.4f;
        [FieldAttr(364)] public float _furHighlightBaseIntensity = 0.6f;
        [FieldAttr(368)] public float _furHighlightMapIntensity = 0.4f;
        [FieldAttr(372)] public float _shellLODDistance = 500.0f;
        [FieldAttr(384)] public igVec4fMetaField _furShape = new();
    }
}
