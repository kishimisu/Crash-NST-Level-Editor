using Alchemy;

namespace Havok
{
    [ObjectAttr(32)]
    public class hkbClipTriggerArray : hkReferencedObject
    {
        public override uint Hash => 0xf757cd66;

        [FieldAttr(16)] public hkMemory<hkbClipTrigger> _triggers; // TYPE_ARRAY, ctype: hkbClipTrigger, subtype: TYPE_STRUCT
    }
}