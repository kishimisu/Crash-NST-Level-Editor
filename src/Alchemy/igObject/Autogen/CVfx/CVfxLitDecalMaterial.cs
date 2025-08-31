namespace Alchemy
{
    [ObjectAttr(368, 16)]
    public class CVfxLitDecalMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class TextureBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(3, size: 1)] public bool _textureCompression_normal = false;
            [FieldAttr(4, size: 1)] public bool _textureMips_normal = false;
            [FieldAttr(5, size: 1)] public bool _textureCompression_gloss = false;
            [FieldAttr(6, size: 1)] public bool _textureMips_gloss = false;
            [FieldAttr(7, size: 1)] public bool _textureAllowDownsample_gloss = false;
            [FieldAttr(8, size: 1)] public bool _textureCompression_metal = false;
            [FieldAttr(9, size: 1)] public bool _textureMips_metal = false;
            [FieldAttr(10, size: 1)] public bool _textureAllowDownsample_metal = false;
            [FieldAttr(11, size: 1)] public bool _textureCompression_emissive = false;
            [FieldAttr(12, size: 1)] public bool _textureMips_emissive = false;
            [FieldAttr(13, size: 1)] public bool _textureAllowDownsample_emissive = false;
        }

        [ObjectAttr(1)]
        public class BfStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureAllowDownsample_normal = true;
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
        [FieldAttr(128)] public string? _textureName_diffuse = "textures";
        [FieldAttr(136)] public string? _textureName_normal = "textures";
        [FieldAttr(144)] public BfStorage _bfStorage__0 = new();
        [FieldAttr(152)] public string? _textureName_gloss = "textures";
        [FieldAttr(160)] public string? _textureName_metal = "textures";
        [FieldAttr(168)] public string? _textureName_emissive = "textures";
        [FieldAttr(176)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(240)] public igVec4fMetaField _color = new();
        [FieldAttr(256)] public bool _enableFadeAngle;
        [FieldAttr(260)] public float _fadeStartAngle = 45.0f;
        [FieldAttr(264)] public float _fadeEndAngle = 60.0f;
        [FieldAttr(272)] public igVec4fMetaField _alphaScaleOffset = new();
        [FieldAttr(288)] public bool _enableEdgeFade;
        [FieldAttr(304)] public igVec4fMetaField _edgeFadeDistances = new();
        [FieldAttr(320)] public igVec4fMetaField _edgeFadeOffset = new();
        [FieldAttr(336)] public igVec4fMetaField _edgeFadeScale = new();
        [FieldAttr(352)] public BlendChannelsBitfield _blendChannelsBitfield = new();
    }
}
