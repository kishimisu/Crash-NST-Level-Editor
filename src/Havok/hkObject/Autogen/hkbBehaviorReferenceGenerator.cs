using Alchemy;

namespace Havok
{
    [ObjectAttr(152)]
    public class hkbBehaviorReferenceGenerator : hkbGenerator
    {
        public override uint Hash => 0x154fcfaa;

        [FieldAttr(136)] public string _behaviorName; // TYPE_STRINGPTR
        [FieldAttr(144)] public u32 _behavior; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}