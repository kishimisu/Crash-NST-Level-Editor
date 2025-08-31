namespace Alchemy
{
    [ObjectAttr(272, 16)]
    public class CVfxMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class VfxMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isSoftParticle;
            [FieldAttr(1, size: 1)] public bool _softParticlePalettized;
            [FieldAttr(2, size: 1)] public bool _enableHaze = false;
            [FieldAttr(3, size: 1)] public bool _additive;
            [FieldAttr(4, size: 1)] public bool _premultiplied;
            [FieldAttr(5, size: 1)] public bool _enableEnvironmentLighting = false;
            [FieldAttr(6, size: 1)] public bool _textureCompression_diffuse = false;
            [FieldAttr(7, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(8, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(9, size: 1)] public bool _textureCompression_palette = false;
            [FieldAttr(10, size: 1)] public bool _textureMips_palette;
            [FieldAttr(11, size: 1)] public bool _useOriginalTextureName;
        }

        [FieldAttr(120)] public u8 _bfStorage__0;
        [FieldAttr(124)] public float _sortDepthOffset;
        [FieldAttr(128)] public VfxMaterialBitfield _vfxMaterialBitfield = new();
        [FieldAttr(132)] public float _particleSoftness = 14.0f;
        [FieldAttr(136)] public string? _textureName_diffuse = "textures";
        [FieldAttr(144)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(208)] public string? _textureName_palette = null;
        [FieldAttr(216)] public float _particleSaturationMultiplier = 1.0f;
        [FieldAttr(224)] public string? _textureName = null;
        [FieldAttr(240)] public igVec4fMetaField _color = new();
        [FieldAttr(256)] public float _particleSoftnessInverse;
    }
}
