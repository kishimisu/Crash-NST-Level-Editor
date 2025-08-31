namespace Alchemy
{
    [ObjectAttr(400, 16)]
    public class CVfxTwoLayerMaterial : igFxMaterial
    {
        public enum ELayerColorAlphaModes : uint
        {
            kLayerUseAlphaMask = 0,
            kLayerNoAlphaMask = 1,
        }

        public enum ELayerBlendModes : uint
        {
            kBlendModeNormal = 0,
            kBlendModeScreenLayer1Layer2 = 1,
            kBlendModeAddLayer1Layer2 = 2,
            kLBlendModeMultiplyLayer1Layer2 = 3,
        }

        public enum EInstanceColorModes : uint
        {
            kInstanceColorMultiplyFinalColor = 0,
            kInstanceColorMultiplyLayer2Color = 1,
        }

        public enum EFinalAlphaModes : uint
        {
            kFinalAlphaLayer1 = 0,
            kFinalAlphaLayer2 = 1,
            kFinalAlphaMultiplyLayer1Layer2 = 2,
            kFinalAlphaScreenLayer1Layer2 = 3,
        }

        [ObjectAttr(4)]
        public class VfxTwoLayerMaterialBitfield : igBitFieldMetaField
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
            [FieldAttr(9, size: 1)] public bool _textureCompression_mask = false;
            [FieldAttr(10, size: 1)] public bool _textureMips_mask = false;
            [FieldAttr(11, size: 1)] public bool _textureAllowDownsample_mask = false;
            [FieldAttr(12, size: 1)] public bool _textureCompression_palette = false;
            [FieldAttr(13, size: 1)] public bool _textureMips_palette;
            [FieldAttr(14, size: 1)] public bool _useOriginalTextureName;
        }

        [FieldAttr(120)] public u8 _bfStorage__0;
        [FieldAttr(124)] public VfxTwoLayerMaterialBitfield _vfxTwoLayerMaterialBitfield = new();
        [FieldAttr(128)] public float _sortDepthOffset;
        [FieldAttr(132)] public float _particleSoftness = 14.0f;
        [FieldAttr(136)] public string? _textureName_diffuse = "textures";
        [FieldAttr(144)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(208)] public string? _textureName_mask = "textures";
        [FieldAttr(224)] public igMatrix44fMetaField _textureTransform2 = new();
        [FieldAttr(288)] public string? _textureName_palette = null;
        [FieldAttr(296)] public ELayerColorAlphaModes _layer1Color;
        [FieldAttr(300)] public ELayerColorAlphaModes _layer2Color = CVfxTwoLayerMaterial.ELayerColorAlphaModes.kLayerNoAlphaMask;
        [FieldAttr(304)] public ELayerBlendModes _blendMode;
        [FieldAttr(308)] public EInstanceColorModes _instanceColorMode;
        [FieldAttr(312)] public EFinalAlphaModes _finalAlphaMode = CVfxTwoLayerMaterial.EFinalAlphaModes.kFinalAlphaLayer2;
        [FieldAttr(316)] public float _layer1Alpha;
        [FieldAttr(320)] public float _layer2Alpha;
        [FieldAttr(324)] public float _blendMode0;
        [FieldAttr(328)] public float _blendMode1;
        [FieldAttr(332)] public float _instanceColor;
        [FieldAttr(336)] public float _alphaBlendMode0;
        [FieldAttr(340)] public float _alphaBlendMode1;
        [FieldAttr(344)] public float _particleSaturationMultiplier = 1.0f;
        [FieldAttr(352)] public string? _textureName = null;
        [FieldAttr(368)] public igVec4fMetaField _color = new();
        [FieldAttr(384)] public float _particleSoftnessInverse;
    }
}
