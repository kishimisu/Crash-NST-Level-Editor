namespace Alchemy
{
    [ObjectAttr(240, 16)]
    public class CButtonPromptMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class TextureBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
        }

        [FieldAttr(120)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(128)] public string? _textureName_diffuse = null;
        [FieldAttr(144)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(208)] public igVec4fMetaField _color = new();
        [FieldAttr(224)] public bool _tonemap = true;
    }
}
