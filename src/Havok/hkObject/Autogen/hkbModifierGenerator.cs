using Alchemy;

namespace Havok
{
    [ObjectAttr(152)]
    public class hkbModifierGenerator : hkbGenerator
    {
        public override uint Hash => 0xc499fc9e;

        [FieldAttr(136)] public hkbModifier _modifier; // TYPE_POINTER, ctype: hkbModifier, subtype: TYPE_STRUCT
        [FieldAttr(144)] public hkbGenerator _generator; // TYPE_POINTER, ctype: hkbGenerator, subtype: TYPE_STRUCT
    }
}