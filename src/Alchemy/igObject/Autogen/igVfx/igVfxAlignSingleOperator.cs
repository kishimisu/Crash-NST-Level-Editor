namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxAlignSingleOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class AlignFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _sourceFrame = EReferenceFrame.eRF_Camera;
            [FieldAttr(4, size: 3)] public ESourceAxis _sourceAxis = ESourceAxis.eSA_XAxis;
            [FieldAttr(7, size: 1)] public bool _flip1;
        }

        [FieldAttr(24)] public AlignFlags _alignFlags = new();
        [FieldAttr(32)] public igVec3fAlignedMetaField _axis = new();
    }
}
