namespace Alchemy
{
    [ObjectAttr(496, 16)]
    public class CWaterMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class TextureBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_surface = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_surface = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_surface = false;
            [FieldAttr(3, size: 1)] public bool _textureCompression_normal = false;
            [FieldAttr(4, size: 1)] public bool _textureMips_normal = false;
            [FieldAttr(5, size: 1)] public bool _textureAllowDownsample_normal = false;
            [FieldAttr(6, size: 1)] public bool _textureCompression_normal2 = false;
            [FieldAttr(7, size: 1)] public bool _textureMips_normal2 = false;
            [FieldAttr(8, size: 1)] public bool _textureAllowDownsample_normal2 = false;
        }

        [FieldAttr(120)] public string? _shaderName = "Water";
        [FieldAttr(128)] public float _normalMapScale = 1.0f;
        [FieldAttr(132)] public float _normalMapScale2 = 1.0f;
        [FieldAttr(136)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(144)] public string? _textureName_surface = null;
        [FieldAttr(152)] public string? _textureName_normal = null;
        [FieldAttr(160)] public string? _textureName_normal2 = null;
        [FieldAttr(176)] public igMatrix44fMetaField _surfaceTransform = new();
        [FieldAttr(240)] public igMatrix44fMetaField _normalTransform = new();
        [FieldAttr(304)] public igMatrix44fMetaField _normal2Transform = new();
        [FieldAttr(368)] public igVec4fMetaField _deepWaterColor = new();
        [FieldAttr(384)] public float _absorbtion = 2.5f;
        [FieldAttr(388)] public float _gloss = 0.34999999f;
        [FieldAttr(392)] public float _specularLevel = 0.06f;
        [FieldAttr(396)] public float _surfaceGloss = 0.34999999f;
        [FieldAttr(400)] public float _surfaceSpecularLevel = 0.06f;
        [FieldAttr(404)] public float _refractionScale = 0.05f;
        [FieldAttr(408)] public float _mobileConstantDepth = 300.0f;
        [FieldAttr(412)] public float _mobileConstantTransmission;
        [FieldAttr(416)] public bool _enableMotionBlur;
        [FieldAttr(417)] public bool _applyWaterSimulationNormals;
        [FieldAttr(418)] public bool _enableScreenSpaceReflections;
        [FieldAttr(419)] public bool _enableRefraction = true;
        [FieldAttr(420)] public bool _invisible;
        [FieldAttr(432)] public igVec4fMetaField _ambientPrecompute = new();
        [FieldAttr(448)] public igVec4fMetaField _lightingPrecompute = new();
        [FieldAttr(464)] public igVec4fMetaField _ambientPrecomputeSurface = new();
        [FieldAttr(480)] public igVec4fMetaField _lightingPrecomputeSurface = new();
    }
}
