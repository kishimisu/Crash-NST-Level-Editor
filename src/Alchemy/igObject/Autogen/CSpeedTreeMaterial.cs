namespace Alchemy
{
    [ObjectAttr(208, 16)]
    public class CSpeedTreeMaterial : igFxMaterial
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
        [FieldAttr(128)] public string? _textureName_diffuse = null;
        [FieldAttr(136)] public string? _textureName_normal = null;
        [FieldAttr(144)] public string? _textureName_gloss = null;
        [FieldAttr(152)] public string? _textureName_metal = null;
        [FieldAttr(160)] public string? _textureName_backscatter = null;
        [FieldAttr(176)] public igVec4fMetaField _color = new();
        [FieldAttr(192)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
        [FieldAttr(196)] public bool _flipBackfaceNormals = true;
    }
}
