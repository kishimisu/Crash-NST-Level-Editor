using Alchemy;

namespace Havok
{
    [ObjectAttr(32)]
    public class hkbClipTrigger : hkObject
    {
        public override uint Hash => 0x7eb45cea;

        [FieldAttr(0)] public float _localTime; // TYPE_REAL
        [FieldAttr(8)] public hkbEventProperty _event; // TYPE_STRUCT, ctype: hkbEventProperty
        [FieldAttr(24)] public bool _relativeToEndOfClip; // TYPE_BOOL
        [FieldAttr(25)] public bool _acyclic; // TYPE_BOOL
        [FieldAttr(26)] public bool _isAnnotation; // TYPE_BOOL
    }
}