namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxAlignDualOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class AlignFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 2)] public ETargetAxis _targetAxis1 = ETargetAxis.eTA_ZAxis;
            [FieldAttr(2, size: 4)] public EReferenceFrame _sourceFrame1 = EReferenceFrame.eRF_Camera;
            [FieldAttr(6, size: 3)] public ESourceAxis _sourceAxis1 = ESourceAxis.eSA_XAxis;
            [FieldAttr(9, size: 1)] public bool _flip1;
            [FieldAttr(10, size: 2)] public ETargetAxis _targetAxis2 = ETargetAxis.eTA_XAxis;
            [FieldAttr(12, size: 4)] public EReferenceFrame _sourceFrame2 = EReferenceFrame.eRF_World;
            [FieldAttr(16, size: 3)] public ESourceAxis _sourceAxis2 = ESourceAxis.eSA_XAxis;
            [FieldAttr(19, size: 1)] public bool _flip2;
            [FieldAttr(20, size: 1)] public bool _secondAxisPriority;
        }

        [FieldAttr(24)] public AlignFlags _alignFlags = new();
    }
}
