using Alchemy;

namespace Havok
{
    [ObjectAttr(120)]
    public class hknpPhysicsSystemData : hkReferencedObject
    {
        public override uint Hash => 0xb857718b;

        [FieldAttr(16)] public hkMemory<hknpMaterial> _materials; // TYPE_ARRAY, ctype: hknpMaterial, subtype: TYPE_STRUCT
        [FieldAttr(32)] public hkMemory<hknpMotionProperties> _motionProperties; // TYPE_ARRAY, ctype: hknpMotionProperties, subtype: TYPE_STRUCT
        [FieldAttr(48)] public hkMemory<hknpMotionCinfo> _motionCinfos; // TYPE_ARRAY, ctype: hknpMotionCinfo, subtype: TYPE_STRUCT
        [FieldAttr(64)] public hkMemory<hknpBodyCinfo> _bodyCinfos; // TYPE_ARRAY, ctype: hknpBodyCinfo, subtype: TYPE_STRUCT
        [FieldAttr(80)] public hkMemory<hknpConstraintCinfo> _constraintCinfos; // TYPE_ARRAY, ctype: hknpConstraintCinfo, subtype: TYPE_STRUCT
        [FieldAttr(96)] public hkMemoryPtr<hkReferencedObject> _referencedObjects; // TYPE_ARRAY, ctype: hkReferencedObject, subtype: TYPE_POINTER
        [FieldAttr(112)] public string _name; // TYPE_STRINGPTR
    }
}