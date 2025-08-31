namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxAlignLineBillboardOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class AlignFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_Track1;
            [FieldAttr(4, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
            [FieldAttr(8, size: 1)] public bool _axisAligned = false;
            [FieldAttr(9, size: 1)] public bool _viewPlaneAligned = false;
        }

        [FieldAttr(24)] public AlignFlags _alignFlags = new();
    }
}
