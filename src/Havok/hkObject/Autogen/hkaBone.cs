using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkaBone : hkObject
    {
        public override uint Hash => 0x35912f8a;

        [FieldAttr(0)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(8)] public bool _lockTranslation; // TYPE_BOOL
    }
}