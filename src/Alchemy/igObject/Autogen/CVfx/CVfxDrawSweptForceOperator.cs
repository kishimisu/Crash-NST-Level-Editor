namespace Alchemy
{
    [ObjectAttr(448, 8)]
    public class CVfxDrawSweptForceOperator : CVfxDrawForceOperator
    {
        [ObjectAttr(4)]
        public class SweptFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_Track1;
            [FieldAttr(4, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
        }

        [FieldAttr(440)] public SweptFlags _sweptFlags = new();
    }
}
