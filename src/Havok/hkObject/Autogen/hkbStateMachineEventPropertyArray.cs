using Alchemy;

namespace Havok
{
    [ObjectAttr(32)]
    public class hkbStateMachineEventPropertyArray : hkReferencedObject
    {
        public override uint Hash => 0x71957c2d;

        [FieldAttr(16)] public hkMemory<hkbEventProperty> _events; // TYPE_ARRAY, ctype: hkbEventProperty, subtype: TYPE_STRUCT
    }
}