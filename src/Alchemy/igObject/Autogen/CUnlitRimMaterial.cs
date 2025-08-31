namespace Alchemy
{
    [ObjectAttr(320, 16)]
    public class CUnlitRimMaterial : CUnlitMaterial
    {
        public enum ERampShape : uint
        {
            eRS_ClampFacing = 0,
            eRS_ClampGlancing = 1,
            eRS_ClampPeak = 2,
        }

        [ObjectAttr(4)]
        public class TextureRimBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_palette = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_palette;
            [FieldAttr(2, size: 1)] public bool _flipFacing;
            [FieldAttr(3, size: 1)] public bool _wrapToBack;
            [FieldAttr(4, size: 1)] public bool _facingPalettized;
            [FieldAttr(5, size: 1)] public bool _palettized;
            [FieldAttr(6, size: 1)] public bool _depthBlendingPalettized;
        }

        [FieldAttr(256)] public TextureRimBitfield _textureRimBitfield = new();
        [FieldAttr(264)] public string? _textureName_palette = null;
        [FieldAttr(272)] public ERampShape _rampShape = CUnlitRimMaterial.ERampShape.eRS_ClampPeak;
        [FieldAttr(276)] public float _facingAngle = 75.0f;
        [FieldAttr(288)] public igVec4fMetaField _facingFactors = new();
        [FieldAttr(304)] public float _facingCutoff;
    }
}
