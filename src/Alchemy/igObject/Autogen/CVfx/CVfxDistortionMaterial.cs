namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CVfxDistortionMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class VfxDistortionMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_normal = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_normal = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_normal = false;
            [FieldAttr(3, size: 1)] public bool _textureCompression_mask = false;
            [FieldAttr(4, size: 1)] public bool _textureMips_mask = false;
            [FieldAttr(5, size: 1)] public bool _textureAllowDownsample_mask = false;
        }

        [FieldAttr(120)] public string? _textureName_normal = "textures";
        [FieldAttr(128)] public string? _textureName_mask = "textures";
        [FieldAttr(136)] public string? _normalTexture = null;
        [FieldAttr(144)] public string? _maskTexture = null;
        [FieldAttr(152)] public VfxDistortionMaterialBitfield _vfxDistortionMaterialBitfield = new();
    }
}
