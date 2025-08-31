using Alchemy;

namespace Havok
{
    [ObjectAttr(120)]
    public class hkbStateMachineStateInfo : hkbBindable
    {
        public override uint Hash => 0x39d76713;

        [FieldAttr(48)] public hkMemoryPtr<hkbStateListener> _listeners; // TYPE_ARRAY, ctype: hkbStateListener, subtype: TYPE_POINTER
        [FieldAttr(64)] public hkbStateMachineEventPropertyArray _enterNotifyEvents; // TYPE_POINTER, ctype: hkbStateMachineEventPropertyArray, subtype: TYPE_STRUCT
        [FieldAttr(72)] public hkbStateMachineEventPropertyArray _exitNotifyEvents; // TYPE_POINTER, ctype: hkbStateMachineEventPropertyArray, subtype: TYPE_STRUCT
        [FieldAttr(80)] public hkbStateMachineTransitionInfoArray _transitions; // TYPE_POINTER, ctype: hkbStateMachineTransitionInfoArray, subtype: TYPE_STRUCT
        [FieldAttr(88)] public hkbGenerator _generator; // TYPE_POINTER, ctype: hkbGenerator, subtype: TYPE_STRUCT
        [FieldAttr(96)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(104)] public i32 _stateId; // TYPE_INT32
        [FieldAttr(108)] public float _probability; // TYPE_REAL
        [FieldAttr(112)] public bool _enable; // TYPE_BOOL
        [FieldAttr(113)] public bool _hasEventlessTransitions; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}