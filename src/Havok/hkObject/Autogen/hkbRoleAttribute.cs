using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkbRoleAttribute : hkObject
    {
        public override uint Hash => 0xfecef669;

        [FieldAttr(0)] public ERole _role; // TYPE_ENUM, etype: Role, subtype: TYPE_INT16
        [FieldAttr(2)] public i16 _flags; // TYPE_FLAGS, etype: RoleFlags, subtype: TYPE_INT16
    }
}