using Alchemy;

namespace Havok
{
    [ObjectAttr(208)]
    public class hknpCompressedMeshShapeData : hkReferencedObject
    {
        public override uint Hash => 0xa2bdfc59;

        [FieldAttr(16)] public hknpCompressedMeshShapeTree _meshTree; // TYPE_STRUCT, ctype: hknpCompressedMeshShapeTree
        [FieldAttr(176)] public hkcdSimdTree _simdTree; // TYPE_STRUCT, ctype: hkcdSimdTree
    }
}