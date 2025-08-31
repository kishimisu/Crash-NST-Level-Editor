namespace Alchemy
{
    [ObjectAttr(384, 16)]
    public class CFlowWaterMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class TextureBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_normal = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_normal = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_normal = false;
        }

        [FieldAttr(120)] public string? _shaderName = "FlowWater";
        [FieldAttr(128)] public float _normalMapScale = 1.0f;
        [FieldAttr(132)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(136)] public string? _textureName_normal = null;
        [FieldAttr(144)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(208)] public igVec4fMetaField _deepWaterColor = new();
        [FieldAttr(224)] public igVec4fMetaField _churnWaterColor = new();
        [FieldAttr(240)] public float _invWaveHeightChurnDistance = 0.003f;
        [FieldAttr(244)] public float _absorbtion = 2.5f;
        [FieldAttr(248)] public float _gloss = 0.34999999f;
        [FieldAttr(252)] public float _refractionScale = 0.05f;
        [FieldAttr(256)] public float _maxTextureDistortion = 0.33f;
        [FieldAttr(260)] public float _flowAnimationRate = 2.0f;
        [FieldAttr(264)] public igVec2fMetaField _flowNormalScale = new();
        [FieldAttr(272)] public igVec2fMetaField _flowTexcoordOffset = new();
        [FieldAttr(288)] public igVec4fMetaField _flowProperties = new();
        [FieldAttr(304)] public float _timeScale = 4.0f;
        [FieldAttr(320)] public igVec4fMetaField _ambientPrecompute = new();
        [FieldAttr(336)] public igVec4fMetaField _lightingPrecompute = new();
        [FieldAttr(352)] public bool _enableSoftTransition;
        [FieldAttr(356)] public float _softTransitionDistance = 20.0f;
        [FieldAttr(360)] public float _invSoftTransitionDistance = 0.05f;
        [FieldAttr(364)] public float _mobileConstantDepth = 300.0f;
        [FieldAttr(368)] public float _mobileConstantTransmission;
        [FieldAttr(372)] public bool _isShallowWater;
        [FieldAttr(373)] public bool _isChoppyWater;
        [FieldAttr(374)] public bool _enableMotionBlur;
        [FieldAttr(375)] public bool _applyWaterSimulationNormals;
        [FieldAttr(376)] public bool _enableRefraction = true;
    }
}
