namespace Alchemy
{
    [ObjectAttr(216, 4)]
    public class igVfxTextureTransformScaleCurveOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _diffuse = true;
            [FieldAttr(1, size: 1)] public bool _mask;
        }

        [FieldAttr(24)] public Flags _flags = new();
        [FieldAttr(28)] public igVec2fMetaField _pivot = new();
        [FieldAttr(36)] public igVfxRangedCurveMetaField _uScale = new();
        [FieldAttr(120)] public igVfxRangedCurveMetaField _vScale = new();
        [FieldAttr(204)] public EOperatorCurveInput _input;
        [FieldAttr(208)] public EigVfxCurveCorrelation _correlation;
    }
}
