namespace Alchemy
{
    [ObjectAttr(848, 16)]
    public class igVfxDrawBezierAdvancedOperator : igVfxDrawProcGeometryOperator
    {
        [ObjectAttr(4)]
        public class BezierFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 5)] public int _segmentCount = 17;
            [FieldAttr(5, size: 1)] public bool _scaleHandles = false;
            [FieldAttr(6, size: 4)] public EOperatorCurveInput _offsetInput;
            [FieldAttr(10, size: 3)] public EigVfxCurveCorrelation _offsetCorrelation;
            [FieldAttr(13, size: 1)] public bool _isBillboard = false;
            [FieldAttr(14, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_World;
            [FieldAttr(18, size: 4)] public EReferenceFrame _handleEndpoint1 = EReferenceFrame.eRF_World;
            [FieldAttr(22, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
            [FieldAttr(26, size: 4)] public EReferenceFrame _handleEndpoint2 = EReferenceFrame.eRF_World;
        }

        [ObjectAttr(4)]
        public class BezierFlags2 : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EModulation _widthAlongLengthModulation = EModulation.kModulate;
            [FieldAttr(3, size: 1)] public bool _scaleSideOffset = false;
            [FieldAttr(4, size: 3)] public EModulation _colorAlongLengthModulation = EModulation.kReplace;
            [FieldAttr(7, size: 3)] public EModulation _alphaAlongLengthModulation = EModulation.kReplace;
        }

        [FieldAttr(80)] public BezierFlags _bezierFlags = new();
        [FieldAttr(84)] public BezierFlags2 _bezierFlags2 = new();
        [FieldAttr(88)] public igRangedVectorMetaField _startHandle = new();
        [FieldAttr(112)] public igRangedVectorMetaField _endHandle = new();
        [FieldAttr(136)] public igVfxRangedCurveMetaField _startOffset = new();
        [FieldAttr(220)] public igVfxRangedCurveMetaField _endOffset = new();
        [FieldAttr(304)] public bool _unhinged;
        [FieldAttr(308)] public igVfxRangedCurveMetaField _widthAlongLength = new();
        [FieldAttr(392)] public igVfxRangedCurveMetaField _sideOffsetAlongLength = new();
        [FieldAttr(480)] public igVfxRgbCurveMetaField _colorAlongLength = new();
        [FieldAttr(752)] public igVfxRangedCurveMetaField _alphaAlongLength = new();
    }
}
