namespace Alchemy
{
    [ObjectAttr(304, 16)]
    public class CVfxLitLiquidMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class VfxMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isSoftParticle;
            [FieldAttr(1, size: 1)] public bool _enableHaze = false;
            [FieldAttr(2, size: 1)] public bool _additive;
            [FieldAttr(3, size: 1)] public bool _textureCompression_diffuse = false;
            [FieldAttr(4, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(5, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(6, size: 1)] public bool _textureCompression_mask = false;
            [FieldAttr(7, size: 1)] public bool _textureMips_mask = false;
            [FieldAttr(8, size: 1)] public bool _textureAllowDownsample_mask = false;
            [FieldAttr(9, size: 1)] public bool _textureCompression_normal = false;
            [FieldAttr(10, size: 1)] public bool _textureMips_normal = false;
            [FieldAttr(11, size: 1)] public bool _textureAllowDownsample_normal = false;
        }

        [FieldAttr(120)] public u8 _bfStorage__0;
        [FieldAttr(124)] public float _sortDepthOffset;
        [FieldAttr(128)] public VfxMaterialBitfield _vfxMaterialBitfield = new();
        [FieldAttr(132)] public float _particleSoftness = 14.0f;
        [FieldAttr(136)] public bool _enableThreshold = true;
        [FieldAttr(137)] public bool _enableAlphaThreshold;
        [FieldAttr(144)] public string? _textureName_diffuse = "textures";
        [FieldAttr(152)] public string? _textureName_mask = "textures";
        [FieldAttr(160)] public string? _textureName_normal = "textures";
        [FieldAttr(176)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(240)] public float _particleSoftnessInverse;
        [FieldAttr(244)] public float _normalBendScale;
        [FieldAttr(248)] public float _gloss = 0.8f;
        [FieldAttr(252)] public float _lightWrap = 0.75f;
        [FieldAttr(256)] public float _specularAlphaBoost;
        [FieldAttr(260)] public float _thresholdSize = 0.5f;
        [FieldAttr(272)] public igVec4fMetaField _specParameters = new();
        [FieldAttr(288)] public igVec4fMetaField _lightWrapParameters = new();
    }
}
