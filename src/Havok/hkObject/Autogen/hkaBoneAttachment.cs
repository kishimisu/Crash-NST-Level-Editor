using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(128)]
    public class hkaBoneAttachment : hkReferencedObject
    {
        public override uint Hash => 0xb566faa5;

        [FieldAttr(16)] public string _originalSkeletonName; // TYPE_STRINGPTR
        [FieldAttr(32)] public Matrix4x4 _boneFromAttachment; // TYPE_MATRIX4
        [FieldAttr(96)] public hkReferencedObject _attachment; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
        [FieldAttr(104)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(112)] public i16 _boneIndex; // TYPE_INT16
    }
}