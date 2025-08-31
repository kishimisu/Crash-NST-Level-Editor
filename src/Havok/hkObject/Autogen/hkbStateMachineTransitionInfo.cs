using Alchemy;

namespace Havok
{
    [ObjectAttr(72)]
    public class hkbStateMachineTransitionInfo : hkObject
    {
        public override uint Hash => 0xcdec8025;

        [FieldAttr(0)] public hkbStateMachineTimeInterval _triggerInterval; // TYPE_STRUCT, ctype: hkbStateMachineTimeInterval
        [FieldAttr(16)] public hkbStateMachineTimeInterval _initiateInterval; // TYPE_STRUCT, ctype: hkbStateMachineTimeInterval
        [FieldAttr(32)] public hkbTransitionEffect _transition; // TYPE_POINTER, ctype: hkbTransitionEffect, subtype: TYPE_STRUCT
        [FieldAttr(40)] public hkbCondition _condition; // TYPE_POINTER, ctype: hkbCondition, subtype: TYPE_STRUCT
        [FieldAttr(48)] public i32 _eventId; // TYPE_INT32
        [FieldAttr(52)] public i32 _toStateId; // TYPE_INT32
        [FieldAttr(56)] public i32 _fromNestedStateId; // TYPE_INT32
        [FieldAttr(60)] public i32 _toNestedStateId; // TYPE_INT32
        [FieldAttr(64)] public i16 _priority; // TYPE_INT16
        [FieldAttr(66)] public i16 _flags; // TYPE_FLAGS, etype: TransitionFlags, subtype: TYPE_INT16
    }
}