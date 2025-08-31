using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbStateMachineTransitionInfoArray : hkReferencedObject
    {
        public override uint Hash => 0x704a19af;

        [FieldAttr(16)] public hkMemory<hkbStateMachineTransitionInfo> _transitions; // TYPE_ARRAY, ctype: hkbStateMachineTransitionInfo, subtype: TYPE_STRUCT
        [FieldAttr(32)] public bool _hasEventlessTransitions; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(33)] public bool _hasTimeBoundedTransitions; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}