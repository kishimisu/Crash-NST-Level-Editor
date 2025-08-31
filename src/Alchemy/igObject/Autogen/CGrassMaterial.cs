namespace Alchemy
{
    [ObjectAttr(304, 16)]
    public class CGrassMaterial : igFxMaterial
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
            [FieldAttr(12, size: 1)] public bool _textureCompression_backscatter = false;
            [FieldAttr(13, size: 1)] public bool _textureMips_backscatter = false;
            [FieldAttr(14, size: 1)] public bool _textureAllowDownsample_backscatter = false;
        }

        [FieldAttr(120)] public float _normalMapScale = 1.0f;
        [FieldAttr(124)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(128)] public bool _hasNormalMap = true;
        [FieldAttr(129)] public bool _hasPackMap = true;
        [FieldAttr(136)] public string? _textureName_diffuse = null;
        [FieldAttr(144)] public string? _textureName_normal = null;
        [FieldAttr(152)] public string? _textureName_gloss = null;
        [FieldAttr(160)] public string? _textureName_metal = null;
        [FieldAttr(168)] public string? _textureName_backscatter = null;
        [FieldAttr(176)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(240)] public float _emissive;
        [FieldAttr(256)] public igVec4fMetaField _color = new();
        [FieldAttr(272)] public bool grass_animation_state = true;
        [FieldAttr(276)] public float grass_animation_rate = 1.0f;
        [FieldAttr(280)] public float grass_calm_distance = 5.0f;
        [FieldAttr(284)] public float grass_windy_distance = 10.0f;
        [FieldAttr(288)] public bool grass_interactive;
        [FieldAttr(289)] public bool _billboard;
        [FieldAttr(290)] public bool _useBillboardOriginForPivot = true;
        [FieldAttr(291)] public bool _useCameraDirectionForBillboard;
        [FieldAttr(292)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
    }
}
