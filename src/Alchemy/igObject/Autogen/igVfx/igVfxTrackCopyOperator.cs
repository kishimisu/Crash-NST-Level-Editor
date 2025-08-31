namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxTrackCopyOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _destinationTrack = EReferenceFrame.eRF_Track2;
            [FieldAttr(4, size: 1)] public bool _copyPose = false;
            [FieldAttr(5, size: 1)] public bool _copyMotion = false;
            [FieldAttr(6, size: 1)] public bool _copyColor = false;
            [FieldAttr(7, size: 1)] public bool _copySize = false;
            [FieldAttr(8, size: 1)] public bool _copyParameters;
        }

        [FieldAttr(24)] public Flags _flags = new();
    }
}
