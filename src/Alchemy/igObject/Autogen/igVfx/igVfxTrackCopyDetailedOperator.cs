namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxTrackCopyDetailedOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _destinationTrack = EReferenceFrame.eRF_Track2;
            [FieldAttr(4, size: 1)] public bool _copyOrientation = false;
            [FieldAttr(5, size: 1)] public bool _copyPosition = false;
            [FieldAttr(6, size: 1)] public bool _copySpin = false;
            [FieldAttr(7, size: 1)] public bool _copyVelocity = false;
            [FieldAttr(8, size: 1)] public bool _copyColor = false;
            [FieldAttr(9, size: 1)] public bool _copySize = false;
            [FieldAttr(10, size: 1)] public bool _copyParameter1;
            [FieldAttr(11, size: 1)] public bool _copyParameter2;
            [FieldAttr(12, size: 1)] public bool _copyParameter3;
            [FieldAttr(13, size: 1)] public bool _copyParameter4;
        }

        [FieldAttr(24)] public Flags _flags = new();
    }
}
