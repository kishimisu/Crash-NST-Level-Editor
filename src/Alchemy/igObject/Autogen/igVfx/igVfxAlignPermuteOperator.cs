namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 24, align: 8)]
    public class igVfxAlignPermuteOperator : igVfxOperator
    {
        [ObjectAttr(size: 4)]
        public class AlignFlags : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 2)] public ETargetAxis _sourceAxisX;
            [FieldAttr(offset: 2, size: 1)] public bool _flipX;
            [FieldAttr(offset: 3, size: 2)] public ETargetAxis _sourceAxisY = ETargetAxis.eTA_XAxis;
            [FieldAttr(offset: 5, size: 1)] public bool _flipY;
        }

        [FieldAttr(nst: 24, ctr: 16)] public AlignFlags _alignFlags = new();
    }
}
