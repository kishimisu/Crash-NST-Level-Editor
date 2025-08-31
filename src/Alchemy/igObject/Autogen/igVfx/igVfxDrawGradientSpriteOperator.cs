namespace Alchemy
{
    [ObjectAttr(464, 16)]
    public class igVfxDrawGradientSpriteOperator : igVfxDrawSpriteOperator
    {
        [ObjectAttr(4)]
        public class SpriteFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _gradientFrame = EReferenceFrame.eRF_Track2;
            [FieldAttr(4, size: 1)] public bool _useWorldUpAxis = false;
        }

        [FieldAttr(88)] public SpriteFlags _spriteFlags = new();
        [FieldAttr(96)] public igVfxRgbCurveMetaField _colorCurve = new();
        [FieldAttr(368)] public igVfxRangedCurveMetaField _alpha = new();
        [FieldAttr(452)] public EOperatorCurveInput _colorInput;
    }
}
