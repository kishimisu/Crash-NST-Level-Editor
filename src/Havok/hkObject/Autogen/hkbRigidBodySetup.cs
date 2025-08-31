using Alchemy;

namespace Havok
{
    [ObjectAttr(32)]
    public class hkbRigidBodySetup : hkObject
    {
        public override uint Hash => 0x3b082f95;

        [FieldAttr(0)] public u32 _collisionFilterInfo; // TYPE_UINT32
        [FieldAttr(4)] public EType _type; // TYPE_ENUM, etype: Type, subtype: TYPE_INT8
        [FieldAttr(8)] public hkbShapeSetup _shapeSetup; // TYPE_STRUCT, ctype: hkbShapeSetup
    }
}