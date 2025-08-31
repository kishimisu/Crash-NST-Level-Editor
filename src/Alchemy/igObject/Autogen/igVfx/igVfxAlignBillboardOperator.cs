namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxAlignBillboardOperator : igVfxFrameOperator
    {
        [ObjectAttr(4)]
        public class AlignFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _axisAligned;
            [FieldAttr(1, size: 1)] public bool _viewPlaneAligned = false;
        }

        [FieldAttr(32)] public AlignFlags _alignFlags = new();
        [FieldAttr(48)] public igVec3fAlignedMetaField _axis = new();
    }
}
