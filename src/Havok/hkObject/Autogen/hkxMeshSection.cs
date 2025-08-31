using Alchemy;

namespace Havok
{
    [ObjectAttr(112)]
    public class hkxMeshSection : hkReferencedObject
    {
        public override uint Hash => 0x54533691;

        [FieldAttr(16)] public hkxVertexBuffer _vertexBuffer; // TYPE_POINTER, ctype: hkxVertexBuffer, subtype: TYPE_STRUCT
        [FieldAttr(24)] public hkMemoryPtr<hkxIndexBuffer> _indexBuffers; // TYPE_ARRAY, ctype: hkxIndexBuffer, subtype: TYPE_POINTER
        [FieldAttr(40)] public hkxMaterial _material; // TYPE_POINTER, ctype: hkxMaterial, subtype: TYPE_STRUCT
        [FieldAttr(48)] public hkMemoryPtr<hkReferencedObject> _userChannels; // TYPE_ARRAY, ctype: hkReferencedObject, subtype: TYPE_POINTER
        [FieldAttr(64)] public hkMemoryPtr<hkxVertexAnimation> _vertexAnimations; // TYPE_ARRAY, ctype: hkxVertexAnimation, subtype: TYPE_POINTER
        [FieldAttr(80)] public hkMemory<float> _linearKeyFrameHints; // TYPE_ARRAY, subtype: TYPE_REAL
        [FieldAttr(96)] public hkMemory<hkMeshBoneIndexMapping> _boneMatrixMap; // TYPE_ARRAY, ctype: hkMeshBoneIndexMapping, subtype: TYPE_STRUCT
    }
}