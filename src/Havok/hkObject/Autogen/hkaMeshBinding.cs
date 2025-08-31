using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(80)]
    public class hkaMeshBinding : hkReferencedObject
    {
        public override uint Hash => 0x32b0ecb6;

        [FieldAttr(16)] public hkxMesh _mesh; // TYPE_POINTER, ctype: hkxMesh, subtype: TYPE_STRUCT
        [FieldAttr(24)] public string _originalSkeletonName; // TYPE_STRINGPTR
        [FieldAttr(32)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(40)] public hkaSkeleton _skeleton; // TYPE_POINTER, ctype: hkaSkeleton, subtype: TYPE_STRUCT
        [FieldAttr(48)] public hkMemory<hkaMeshBindingMapping> _mappings; // TYPE_ARRAY, ctype: hkaMeshBindingMapping, subtype: TYPE_STRUCT
        [FieldAttr(64)] public hkMemory<Matrix4x4> _boneFromSkinMeshTransforms; // TYPE_ARRAY, subtype: TYPE_TRANSFORM
    }
}