using Alchemy;

namespace Havok
{
    [ObjectAttr(96)]
    public class hkaAnimationContainer : hkReferencedObject
    {
        public override uint Hash => 0x26859f4c;

        [FieldAttr(16)] public hkMemoryPtr<hkaSkeleton> _skeletons; // TYPE_ARRAY, ctype: hkaSkeleton, subtype: TYPE_POINTER
        [FieldAttr(32)] public hkMemoryPtr<hkaAnimation> _animations; // TYPE_ARRAY, ctype: hkaAnimation, subtype: TYPE_POINTER
        [FieldAttr(48)] public hkMemoryPtr<hkaAnimationBinding> _bindings; // TYPE_ARRAY, ctype: hkaAnimationBinding, subtype: TYPE_POINTER
        [FieldAttr(64)] public hkMemoryPtr<hkaBoneAttachment> _attachments; // TYPE_ARRAY, ctype: hkaBoneAttachment, subtype: TYPE_POINTER
        [FieldAttr(80)] public hkMemoryPtr<hkaMeshBinding> _skins; // TYPE_ARRAY, ctype: hkaMeshBinding, subtype: TYPE_POINTER
    }
}