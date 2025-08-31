using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbCharacterControllerSetup : hkObject
    {
        public override uint Hash => 0xaf5f7339;

        [FieldAttr(0)] public hkbRigidBodySetup _rigidBodySetup; // TYPE_STRUCT, ctype: hkbRigidBodySetup
        [FieldAttr(32)] public hkReferencedObject _controllerCinfo; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
    }
}