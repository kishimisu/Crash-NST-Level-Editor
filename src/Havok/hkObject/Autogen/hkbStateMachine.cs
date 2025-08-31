using Alchemy;

namespace Havok
{
    [ObjectAttr(336)]
    public class hkbStateMachine : hkbGenerator
    {
        public override uint Hash => 0x1913d1c1;

        [FieldAttr(136)] public hkbEvent _eventToSendWhenStateOrTransitionChanges; // TYPE_STRUCT, ctype: hkbEvent
        [FieldAttr(160)] public hkbCustomIdSelector _startStateIdSelector; // TYPE_POINTER, ctype: hkbCustomIdSelector, subtype: TYPE_STRUCT
        [FieldAttr(168)] public i32 _startStateId; // TYPE_INT32
        [FieldAttr(172)] public i32 _returnToPreviousStateEventId; // TYPE_INT32
        [FieldAttr(176)] public i32 _randomTransitionEventId; // TYPE_INT32
        [FieldAttr(180)] public i32 _transitionToNextHigherStateEventId; // TYPE_INT32
        [FieldAttr(184)] public i32 _transitionToNextLowerStateEventId; // TYPE_INT32
        [FieldAttr(188)] public i32 _syncVariableIndex; // TYPE_INT32
        [FieldAttr(192)] public i32 _currentStateId; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(196)] public bool _wrapAroundStateId; // TYPE_BOOL
        [FieldAttr(197)] public i8 _maxSimultaneousTransitions; // TYPE_INT8
        [FieldAttr(198)] public EStartStateMode _startStateMode; // TYPE_ENUM, etype: StartStateMode, subtype: TYPE_INT8
        [FieldAttr(199)] public EStateMachineSelfTransitionMode _selfTransitionMode; // TYPE_ENUM, etype: StateMachineSelfTransitionMode, subtype: TYPE_INT8
        [FieldAttr(200)] public bool _isActive; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(208)] public hkMemoryPtr<hkbStateMachineStateInfo> _states; // TYPE_ARRAY, ctype: hkbStateMachineStateInfo, subtype: TYPE_POINTER
        [FieldAttr(224)] public hkbStateMachineTransitionInfoArray _wildcardTransitions; // TYPE_POINTER, ctype: hkbStateMachineTransitionInfoArray, subtype: TYPE_STRUCT
        [FieldAttr(232)] public u32 _stateIdToIndexMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(240)] public hkMemory<u32> _activeTransitions; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(256)] public hkMemory<u32> _transitionFlags; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(272)] public hkMemory<u32> _wildcardTransitionFlags; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(288)] public hkMemory<u32> _delayedTransitions; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(304)] public float _timeInState; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(308)] public float _lastLocalTime; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(312)] public i32 _previousStateId; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(316)] public i32 _nextStartStateIndexOverride; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(320)] public bool _stateOrTransitionChanged; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(321)] public bool _echoNextUpdate; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(322)] public bool _hasEventlessWildcardTransitions; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(328)] public u32 _eventIdToTransitionInfoIndicesMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}