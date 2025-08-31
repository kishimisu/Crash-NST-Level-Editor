using Alchemy;

namespace Havok
{
    [ObjectAttr(88)]
    public class hkbModifier : hkbNode
    {
        public override uint Hash => 0xc811e80c;

        [FieldAttr(80)] public bool _enable; // TYPE_BOOL
        [FieldAttr(81)] public bool _padModifier_0; // TYPE_BOOL, arrsize: 3, flags: SERIALIZE_IGNORED
        [FieldAttr(82)] public bool _padModifier_1;
        [FieldAttr(83)] public bool _padModifier_2;
    }
}