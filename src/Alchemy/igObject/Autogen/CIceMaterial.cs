namespace Alchemy
{
    [ObjectAttr(336, 16)]
    public class CIceMaterial : igFxMaterial
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
        }

        [FieldAttr(120)] public float _normalMapScale = 1.0f;
        [FieldAttr(124)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(128)] public string? _textureName_diffuse = null;
        [FieldAttr(136)] public string? _textureName_normal = null;
        [FieldAttr(144)] public string? _textureName_gloss = null;
        [FieldAttr(152)] public string? _textureName_metal = null;
        [FieldAttr(160)] public string? _textureName_emissive = null;
        [FieldAttr(168)] public string? _textureName_backscatter = null;
        [FieldAttr(176)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(240)] public float _absorbtion = 2.5f;
        [FieldAttr(256)] public igVec4fMetaField _color = new();
        [FieldAttr(272)] public igVec4fMetaField _iceColor = new();
        [FieldAttr(288)] public igVec4fMetaField _deepObjectColor = new();
        [FieldAttr(304)] public igVec4fMetaField _shallowObjectColor = new();
        [FieldAttr(320)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
        [FieldAttr(324)] public bool _renderObscured;
    }
}
