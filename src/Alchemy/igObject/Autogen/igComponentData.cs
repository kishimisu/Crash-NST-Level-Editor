namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class igComponentData : igObject
    {
        [ObjectAttr(4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isEnabled = true;
            [FieldAttr(1, size: 1)] public bool _isThreadSafe;
        }

        [FieldAttr(16)] public Bitfield _bitfield = new();
    }
}
