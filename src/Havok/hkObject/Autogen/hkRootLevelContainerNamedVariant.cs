using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkRootLevelContainerNamedVariant : hkObject
    {
        public override uint Hash => 0xb103a2cd;

        [FieldAttr(0)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(8)] public string _className; // TYPE_STRINGPTR
        [FieldAttr(16)] public hkReferencedObject _variant; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
    }
}