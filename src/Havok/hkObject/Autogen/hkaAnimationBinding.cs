using Alchemy;

namespace Havok
{
    [ObjectAttr(88)]
    public class hkaAnimationBinding : hkReferencedObject
    {
        public override uint Hash => 0xfaf9150;

        [FieldAttr(16)] public string _originalSkeletonName; // TYPE_STRINGPTR
        [FieldAttr(24)] public hkaAnimation _animation; // TYPE_POINTER, ctype: hkaAnimation, subtype: TYPE_STRUCT
        [FieldAttr(32)] public hkMemory<i16> _transformTrackToBoneIndices; // TYPE_ARRAY, subtype: TYPE_INT16
        [FieldAttr(48)] public hkMemory<i16> _floatTrackToFloatSlotIndices; // TYPE_ARRAY, subtype: TYPE_INT16
        [FieldAttr(64)] public hkMemory<i16> _partitionIndices; // TYPE_ARRAY, subtype: TYPE_INT16
        [FieldAttr(80)] public EBlendHint _blendHint; // TYPE_ENUM, etype: BlendHint, subtype: TYPE_INT8
    }
}