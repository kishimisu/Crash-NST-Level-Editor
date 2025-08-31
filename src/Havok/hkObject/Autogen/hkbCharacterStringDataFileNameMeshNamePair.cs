using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkbCharacterStringDataFileNameMeshNamePair : hkObject
    {
        public override uint Hash => 0x26c3a96;

        [FieldAttr(0)] public string _fileName; // TYPE_STRINGPTR
        [FieldAttr(8)] public string _meshName; // TYPE_STRINGPTR
    }
}