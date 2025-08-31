using Alchemy;

namespace Havok
{
    [ObjectAttr(48)]
    public class hknpShapeVertexColorPalette : hkReferencedObject
    {
        public override uint Hash => 0xccd7d32;

        [FieldAttr(16)] public hkMemory<float> _unk0; // TYPE_ARRAY, subtype: TYPE_REAL
        [FieldAttr(32)] public hkMemory<float> _unk1; // TYPE_ARRAY, subtype: TYPE_REAL
    }
}