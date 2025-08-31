using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkxVertexDescription : hkObject
    {
        public override uint Hash => 0x476106c0;

        [FieldAttr(0)] public hkMemory<hkxVertexDescriptionElementDecl> _decls; // TYPE_ARRAY, ctype: hkxVertexDescriptionElementDecl, subtype: TYPE_STRUCT
    }
}