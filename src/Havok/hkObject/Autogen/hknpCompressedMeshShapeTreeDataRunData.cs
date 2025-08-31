using Alchemy;

namespace Havok
{
    [ObjectAttr(2)]
    public class hknpCompressedMeshShapeTreeDataRunData : hkObject
    {
        public override uint Hash => 0xc253682b;

        [FieldAttr(0)] public u16 _data; // TYPE_UINT16
    }
}