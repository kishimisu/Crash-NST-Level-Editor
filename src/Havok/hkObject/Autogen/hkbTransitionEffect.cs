using Alchemy;

namespace Havok
{
    [ObjectAttr(168)]
    public class hkbTransitionEffect : hkbGenerator
    {
        public override uint Hash => 0xeca9d564;

        [FieldAttr(136)] public ESelfTransitionMode _selfTransitionMode; // TYPE_ENUM, etype: SelfTransitionMode, subtype: TYPE_INT8
        [FieldAttr(137)] public EEventMode _eventMode; // TYPE_ENUM, etype: EventMode, subtype: TYPE_INT8
        [FieldAttr(138)] public i8 _defaultEventMode; // TYPE_ENUM, subtype: TYPE_INT8, flags: SERIALIZE_IGNORED
        [FieldAttr(144)] public u32 _patchedBindingInfo; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(152)] public u32 _fromGenerator; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(160)] public u32 _toGenerator; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}