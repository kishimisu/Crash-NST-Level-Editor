namespace Alchemy
{
    [ObjectAttr(320, 16)]
    public class CVfxRimMaterial : CVfxMaterial
    {
        public enum ERampShape : uint
        {
            eRS_ClampFacing = 0,
            eRS_ClampGlancing = 1,
            eRS_ClampPeak = 2,
        }

        [ObjectAttr(4)]
        public class VfxRimMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _facingPalettized;
            [FieldAttr(1, size: 1)] public bool _flipFacing;
        }

        [FieldAttr(272)] public VfxRimMaterialBitfield _vfxRimMaterialBitfield = new();
        [FieldAttr(276)] public ERampShape _rampShape = CVfxRimMaterial.ERampShape.eRS_ClampPeak;
        [FieldAttr(280)] public float _facingAngle = 75.0f;
        [FieldAttr(288)] public igVec4fMetaField _facingFactors = new();
        [FieldAttr(304)] public float _facingCutoff;
    }
}
