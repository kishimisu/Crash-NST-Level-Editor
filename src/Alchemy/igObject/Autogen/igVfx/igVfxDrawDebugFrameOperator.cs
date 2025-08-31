namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxDrawDebugFrameOperator : igVfxDrawOperator
    {
        [ObjectAttr(4)]
        public class DebugFrameFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _frame = EReferenceFrame.eRF_Instance;
            [FieldAttr(4, size: 1)] public bool _showColor;
            [FieldAttr(5, size: 1)] public bool _showVelocity;
        }

        [FieldAttr(32)] public DebugFrameFlags _debugFrameFlags = new();
        [FieldAttr(36)] public float _forceSize;
    }
}
