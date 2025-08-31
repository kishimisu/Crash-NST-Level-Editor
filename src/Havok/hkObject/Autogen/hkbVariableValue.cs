using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkbVariableValue : hkObject
    {
        public override uint Hash => 0xb99bd6a;

        [FieldAttr(0)] public i32 _value; // TYPE_INT32
    }
}