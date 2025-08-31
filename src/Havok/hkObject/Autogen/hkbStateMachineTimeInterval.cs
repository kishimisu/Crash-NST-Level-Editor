using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkbStateMachineTimeInterval : hkObject
    {
        public override uint Hash => 0x60a881e5;

        [FieldAttr(0)] public i32 _enterEventId; // TYPE_INT32
        [FieldAttr(4)] public i32 _exitEventId; // TYPE_INT32
        [FieldAttr(8)] public float _enterTime; // TYPE_REAL
        [FieldAttr(12)] public float _exitTime; // TYPE_REAL
    }
}