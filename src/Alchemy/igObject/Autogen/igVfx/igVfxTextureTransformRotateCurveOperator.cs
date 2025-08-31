namespace Alchemy
{
    [ObjectAttr(128, 4)]
    public class igVfxTextureTransformRotateCurveOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _diffuse = true;
            [FieldAttr(1, size: 1)] public bool _mask;
        }

        [FieldAttr(24)] public Flags _flags = new();
        [FieldAttr(28)] public igVec2fMetaField _pivot = new();
        [FieldAttr(36)] public igVfxRangedCurveMetaField _angle = new();
        [FieldAttr(120)] public EOperatorCurveInput _input;
    }
}
