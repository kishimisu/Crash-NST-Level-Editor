using Alchemy;

namespace Havok
{
    [ObjectAttr(8)]
    public class hkbVariableBounds : hkObject
    {
        public override uint Hash => 0x9b766364;

        [FieldAttr(0)] public hkbVariableValue _min; // TYPE_STRUCT, ctype: hkbVariableValue
        [FieldAttr(4)] public hkbVariableValue _max; // TYPE_STRUCT, ctype: hkbVariableValue
    }
}