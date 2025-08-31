using Alchemy;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkxMesh : hkReferencedObject
    {
        public override uint Hash => 0xc0dafc2f;

        [FieldAttr(16)] public hkMemoryPtr<hkxMeshSection> _sections; // TYPE_ARRAY, ctype: hkxMeshSection, subtype: TYPE_POINTER
        [FieldAttr(32)] public hkMemoryPtr<hkxMeshUserChannelInfo> _userChannelInfos; // TYPE_ARRAY, ctype: hkxMeshUserChannelInfo, subtype: TYPE_POINTER
    }
}