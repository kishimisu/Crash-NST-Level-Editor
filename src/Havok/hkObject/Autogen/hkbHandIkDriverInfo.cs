using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbHandIkDriverInfo : hkReferencedObject
    {
        public override uint Hash => 0x3eab47f1;

        [FieldAttr(16)] public hkMemory<hkbHandIkDriverInfoHand> _hands; // TYPE_ARRAY, ctype: hkbHandIkDriverInfoHand, subtype: TYPE_STRUCT
        [FieldAttr(32)] public EBlendCurve _fadeInOutCurve; // TYPE_ENUM, etype: BlendCurve, subtype: TYPE_INT8
    }
}