using Alchemy;

namespace Havok
{
    [ObjectAttr(32)]
    public class hknpShapeMaterialStringPalette : hkReferencedObject
    {
        public override uint Hash => 0x762f32ff;

        [FieldAttr(16)] public hkMemory<string> _entries; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
    }
}