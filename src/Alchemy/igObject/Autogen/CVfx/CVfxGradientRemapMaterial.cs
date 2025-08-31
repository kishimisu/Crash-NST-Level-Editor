namespace Alchemy
{
    [ObjectAttr(288, 16)]
    public class CVfxGradientRemapMaterial : CVfxMaterial
    {
        [ObjectAttr(4)]
        public class VfxMaterialBitfield2 : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_gradient = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_gradient = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_gradient = false;
        }

        [FieldAttr(272)] public VfxMaterialBitfield2 _vfxMaterialBitfield2 = new();
        [FieldAttr(280)] public string? _textureName_gradient = "textures";
    }
}
