using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hknpSparseCompactMapunsignedshort : hkObject
    {
        public override uint Hash => 0x4558127c;

        [FieldAttr(0)] public u32 _secondaryKeyMask; // TYPE_UINT32
        [FieldAttr(4)] public u32 _sencondaryKeyBits; // TYPE_UINT32
        [FieldAttr(8)] public hkMemory<u16> _primaryKeyToIndex; // TYPE_ARRAY, subtype: TYPE_UINT16
        [FieldAttr(24)] public hkMemory<u16> _valueAndSecondaryKeys; // TYPE_ARRAY, subtype: TYPE_UINT16
    }
}