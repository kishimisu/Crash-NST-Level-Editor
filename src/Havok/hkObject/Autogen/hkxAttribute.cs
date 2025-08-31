using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkxAttribute : hkObject
    {
        public override uint Hash => 0x7375cae3;

        [FieldAttr(0)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(8)] public hkReferencedObject _value; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
    }
}