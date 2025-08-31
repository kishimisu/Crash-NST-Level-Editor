namespace Alchemy
{
    [ObjectAttr(256, 8)]
    public class igVfxDrawLineOperator : igVfxDrawProcGeometryOperator
    {
        [ObjectAttr(4)]
        public class LineFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EigVfxCurveCorrelation _offsetCorrelation;
            [FieldAttr(3, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_World;
            [FieldAttr(7, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
            [FieldAttr(11, size: 1)] public bool _fastNormals;
        }

        [FieldAttr(80)] public LineFlags _lineFlags = new();
        [FieldAttr(84)] public igVfxRangedCurveMetaField _startOffset = new();
        [FieldAttr(168)] public igVfxRangedCurveMetaField _endOffset = new();
        [FieldAttr(252)] public EOperatorCurveInput _offsetInput;
    }
}
