namespace Alchemy
{
    [ObjectAttr(216, 4)]
    public class igVfxTextureMacroOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _diffuse = true;
            [FieldAttr(1, size: 1)] public bool _mask;
            [FieldAttr(2, size: 4)] public EReferenceFrame _frame = EReferenceFrame.eRF_World;
        }

        [FieldAttr(24)] public Flags _flags = new();
        [FieldAttr(28)] public igVec2fMetaField _pivot = new();
        [FieldAttr(36)] public igVfxRangedCurveMetaField _scaleX = new();
        [FieldAttr(120)] public igVfxRangedCurveMetaField _scaleY = new();
        [FieldAttr(204)] public EOperatorCurveInput _scaleInput;
        [FieldAttr(208)] public EigVfxCurveCorrelation _scaleCorrelation;
    }
}
