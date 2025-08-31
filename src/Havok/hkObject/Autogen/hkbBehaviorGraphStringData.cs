using Alchemy;

namespace Havok
{
    [ObjectAttr(80)]
    public class hkbBehaviorGraphStringData : hkReferencedObject
    {
        public override uint Hash => 0x1bd27f38;

        [FieldAttr(16)] public hkMemory<string> _eventNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(32)] public hkMemory<string> _attributeNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(48)] public hkMemory<string> _variableNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(64)] public hkMemory<string> _characterPropertyNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
    }
}