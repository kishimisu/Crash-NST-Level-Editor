namespace Alchemy
{
    [ObjectAttr(nst: 336, ctr: 336, align: 16)]
    public class CGuiTwoLayerMaterial : igFxMaterial
    {
        public enum ELayerColorAlphaModes
        {
            kLayerUseAlphaMask = 0,
            kLayerNoAlphaMask = 1,
        }

        public enum ELayerBlendModes
        {
            kBlendModeNormal = 0,
            kBlendModeScreenLayer1Layer2 = 1,
            kBlendModeAddLayer1Layer2 = 2,
            kLBlendModeMultiplyLayer1Layer2 = 3,
        }

        public enum EInstanceColorModes
        {
            kInstanceColorMultiplyFinalColor = 0,
            kInstanceColorMultiplyLayer2Color = 1,
        }

        public enum EFinalAlphaModes
        {
            kFinalAlphaLayer1 = 0,
            kFinalAlphaLayer2 = 1,
            kFinalAlphaMultiplyLayer1Layer2 = 2,
            kFinalAlphaScreenLayer1Layer2 = 3,
        }

        [ObjectAttr(size: 4)]
        public class GuiTwoLayerMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(offset: 1, size: 1)] public bool _textureMips_diffuse;
            [FieldAttr(offset: 2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(offset: 3, size: 1)] public bool _textureCompression_mask = false;
            [FieldAttr(offset: 4, size: 1)] public bool _textureMips_mask = false;
            [FieldAttr(offset: 5, size: 1)] public bool _textureAllowDownsample_mask = false;
        }

        [FieldAttr(nst: 120, ctr: 120)] public u8 _bfStorage__0;
        [FieldAttr(nst: 124, ctr: 124)] public GuiTwoLayerMaterialBitfield _GuiTwoLayerMaterialBitfield = new();
        [FieldAttr(nst: 128, ctr: 128)] public string? _textureName_diffuse = "textures";
        [FieldAttr(nst: 144, ctr: 144)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(nst: 208, ctr: 208)] public string? _textureName_mask = "textures";
        [FieldAttr(nst: 224, ctr: 224)] public igMatrix44fMetaField _textureTransform2 = new();
        [FieldAttr(nst: 288, ctr: 288)] public ELayerColorAlphaModes _layer1Color;
        [FieldAttr(nst: 292, ctr: 292)] public ELayerColorAlphaModes _layer2Color = CGuiTwoLayerMaterial.ELayerColorAlphaModes.kLayerNoAlphaMask;
        [FieldAttr(nst: 296, ctr: 296)] public ELayerBlendModes _blendMode;
        [FieldAttr(nst: 300, ctr: 300)] public EInstanceColorModes _instanceColorMode;
        [FieldAttr(nst: 304, ctr: 304)] public EFinalAlphaModes _finalAlphaMode = CGuiTwoLayerMaterial.EFinalAlphaModes.kFinalAlphaLayer2;
        [FieldAttr(nst: 308, ctr: 308)] public float _layer1Alpha;
        [FieldAttr(nst: 312, ctr: 312)] public float _layer2Alpha;
        [FieldAttr(nst: 316, ctr: 316)] public float _blendMode0;
        [FieldAttr(nst: 320, ctr: 320)] public float _blendMode1;
        [FieldAttr(nst: 324, ctr: 324)] public float _instanceColor;
        [FieldAttr(nst: 328, ctr: 328)] public float _alphaBlendMode0;
        [FieldAttr(nst: 332, ctr: 332)] public float _alphaBlendMode1;
    }
}
