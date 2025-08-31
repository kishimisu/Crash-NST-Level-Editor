namespace Alchemy
{
    [ObjectAttr(208, 4)]
    public class igVfxTextureTransformTranslateCurveOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _diffuse = true;
            [FieldAttr(1, size: 1)] public bool _mask;
        }

        [FieldAttr(24)] public Flags _flags = new();
        [FieldAttr(28)] public igVfxRangedCurveMetaField _uTranslate = new();
        [FieldAttr(112)] public igVfxRangedCurveMetaField _vTranslate = new();
        [FieldAttr(196)] public EOperatorCurveInput _input;
        [FieldAttr(200)] public EigVfxCurveCorrelation _correlation;
    }
}
