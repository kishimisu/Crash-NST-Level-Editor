using Alchemy;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkxMeshUserChannelInfo : hkxAttributeHolder
    {
        public override uint Hash => 0xa2c8a371;

        [FieldAttr(32)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(40)] public string _className; // TYPE_STRINGPTR
    }
}