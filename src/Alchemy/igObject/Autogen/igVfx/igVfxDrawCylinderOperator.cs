namespace Alchemy
{
    [ObjectAttr(432, 8)]
    public class igVfxDrawCylinderOperator : igVfxDrawProcGeometryOperator
    {
        [ObjectAttr(4)]
        public class CylinderFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EigVfxCurveCorrelation _offsetCorrelation;
            [FieldAttr(3, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_World;
            [FieldAttr(7, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
            [FieldAttr(11, size: 1)] public bool _alignNormalsToCap;
        }

        [FieldAttr(80)] public CylinderFlags _cylinderFlags = new();
        [FieldAttr(84)] public igVfxRangedCurveMetaField _startOffset = new();
        [FieldAttr(168)] public igVfxRangedCurveMetaField _endOffset = new();
        [FieldAttr(252)] public EOperatorCurveInput _offsetInput;
        [FieldAttr(256)] public igVfxRangedCurveMetaField _startArcAngle = new();
        [FieldAttr(340)] public igVfxRangedCurveMetaField _endArcAngle = new();
        [FieldAttr(424)] public EOperatorCurveInput _arcAngleInput;
    }
}
