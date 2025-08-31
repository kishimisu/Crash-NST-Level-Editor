using Alchemy;

namespace Havok
{
    [ObjectAttr(104)]
    public class hkbModifierList : hkbModifier
    {
        public override uint Hash => 0xded564c;

        [FieldAttr(88)] public hkMemoryPtr<hkbModifier> _modifiers; // TYPE_ARRAY, ctype: hkbModifier, subtype: TYPE_POINTER
    }
}