namespace Alchemy
{
    [ObjectAttr(128, 4)]
    public class igVfxTextureTransformFilmstripOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _diffuse = true;
            [FieldAttr(1, size: 1)] public bool _mask;
            [FieldAttr(2, size: 1)] public bool _wrapMode = false;
            [FieldAttr(3, size: 1)] public bool _bounceMode;
        }

        [FieldAttr(24)] public Flags _flags = new();
        [FieldAttr(28)] public igVfxRangedCurveMetaField _frame = new();
        [FieldAttr(112)] public EOperatorCurveInput _input;
        [FieldAttr(116)] public u8 _rows = 1;
        [FieldAttr(117)] public u8 _columns = 1;
        [FieldAttr(118)] public bool _useFrameRange;
        [FieldAttr(120)] public uint _startFrame;
        [FieldAttr(124)] public uint _endFrame;
    }
}
