namespace Alchemy
{
    [ObjectAttr(256, 16)]
    public class CUnlitMaterial : igFxMaterial
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
        [FieldAttr(224)] public bool _renderObscured;
        [FieldAttr(225)] public bool _prepassDepth = true;
        [FieldAttr(226)] public bool basic_haze = true;
        [FieldAttr(227)] public bool basic_additive_haze;
        [FieldAttr(228)] public bool basic_additive;
        [FieldAttr(229)] public bool _onlyDrawInTools;
        [FieldAttr(232)] public ECastShadows _castShadows = ECastShadows.eCS_Yes;
        [FieldAttr(236)] public bool _depthBlendingState;
        [FieldAttr(240)] public float _depthBlendingSoftness = 14.0f;
        [FieldAttr(244)] public float _depthBlendingSoftnessInverse;
        [FieldAttr(248)] public bool _excludeFromDecimation;
    }
}
