using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkbShapeSetup : hkObject
    {
        public override uint Hash => 0xd7ff86be;

        [FieldAttr(0)] public float _capsuleHeight; // TYPE_REAL
        [FieldAttr(4)] public float _capsuleRadius; // TYPE_REAL
        [FieldAttr(8)] public string _fileName; // TYPE_STRINGPTR
        [FieldAttr(16)] public EType _type; // TYPE_ENUM, etype: Type, subtype: TYPE_INT8
    }
}