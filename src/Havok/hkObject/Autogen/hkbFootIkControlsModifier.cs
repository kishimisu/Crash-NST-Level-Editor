using Alchemy;

namespace Havok
{
    [ObjectAttr(192)]
    public class hkbFootIkControlsModifier : hkbModifier
    {
        public override uint Hash => 0xccea286;

        [FieldAttr(96)] public hkbFootIkControlData _controlData; // TYPE_STRUCT, ctype: hkbFootIkControlData
        [FieldAttr(176)] public hkMemory<hkbFootIkControlsModifierLeg> _legs; // TYPE_ARRAY, ctype: hkbFootIkControlsModifierLeg, subtype: TYPE_STRUCT
    }
}