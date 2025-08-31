namespace Alchemy
{
    [ObjectAttr(312, 8)]
    public class igVfxDrawBezierOperator : igVfxDrawProcGeometryOperator
    {
        [ObjectAttr(4)]
        public class BezierFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 5)] public int _segmentCount = 17;
            [FieldAttr(5, size: 1)] public bool _scaleHandles = false;
            [FieldAttr(6, size: 1)] public bool _scaleChaos = false;
            [FieldAttr(7, size: 3)] public EigVfxCurveCorrelation _offsetCorrelation;
            [FieldAttr(10, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_World;
            [FieldAttr(14, size: 4)] public EReferenceFrame _handleEndpoint1 = EReferenceFrame.eRF_World;
            [FieldAttr(18, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
            [FieldAttr(22, size: 4)] public EReferenceFrame _handleEndpoint2 = EReferenceFrame.eRF_World;
        }

        [FieldAttr(80)] public BezierFlags _bezierFlags = new();
        [FieldAttr(84)] public igRangedVectorMetaField _startHandle = new();
        [FieldAttr(108)] public igRangedVectorMetaField _endHandle = new();
        [FieldAttr(132)] public float _chaos;
        [FieldAttr(136)] public igVfxRangedCurveMetaField _startOffset = new();
        [FieldAttr(220)] public igVfxRangedCurveMetaField _endOffset = new();
        [FieldAttr(304)] public EOperatorCurveInput _offsetInput;
    }
}
