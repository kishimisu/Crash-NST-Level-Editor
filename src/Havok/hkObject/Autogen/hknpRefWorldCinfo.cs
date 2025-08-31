using Alchemy;

namespace Havok
{
    [ObjectAttr(272)]
    public class hknpRefWorldCinfo : hkReferencedObject
    {
        public override uint Hash => 0xfbaaa6df;

        [FieldAttr(16)] public hknpWorldCinfo _info; // TYPE_STRUCT, ctype: hknpWorldCinfo
    }
}