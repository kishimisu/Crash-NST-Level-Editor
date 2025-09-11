using Alchemy;

namespace Havok
{
    [ObjectAttr(144)]
    public class hkbReferencePoseGenerator : hkbGenerator
    {
        public override uint Hash => 0xbc1536ee;

        [FieldAttr(136)] public u32 _skeleton; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}