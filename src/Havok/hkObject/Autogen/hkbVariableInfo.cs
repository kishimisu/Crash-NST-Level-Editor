using Alchemy;

namespace Havok
{
    [ObjectAttr(6)]
    public class hkbVariableInfo : hkObject
    {
        public override uint Hash => 0xa5ae6be2;

        [FieldAttr(0)] public hkbRoleAttribute _role; // TYPE_STRUCT, ctype: hkbRoleAttribute
        [FieldAttr(4)] public EVariableType _type; // TYPE_ENUM, etype: VariableType, subtype: TYPE_INT8
    }
}