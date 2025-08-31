using Alchemy;

namespace Havok
{
    [ObjectAttr(208)]
    public class hkbManualSelectorGenerator : hkbGenerator
    {
        public override uint Hash => 0xeed8d5cd;

        [FieldAttr(136)] public hkMemoryPtr<hkbGenerator> _generators; // TYPE_ARRAY, ctype: hkbGenerator, subtype: TYPE_POINTER
        [FieldAttr(152)] public i16 _selectedGeneratorIndex; // TYPE_INT16
        [FieldAttr(160)] public hkbCustomIdSelector _indexSelector; // TYPE_POINTER, ctype: hkbCustomIdSelector, subtype: TYPE_STRUCT
        [FieldAttr(168)] public bool _selectedIndexCanChangeAfterActivate; // TYPE_BOOL
        [FieldAttr(176)] public hkbTransitionEffect _generatorChangedTransitionEffect; // TYPE_POINTER, ctype: hkbTransitionEffect, subtype: TYPE_STRUCT
        [FieldAttr(184)] public i16 _currentGeneratorIndex; // TYPE_INT16, flags: SERIALIZE_IGNORED
        [FieldAttr(186)] public i16 _generatorIndexAtActivate; // TYPE_INT16, flags: SERIALIZE_IGNORED
        [FieldAttr(192)] public hkMemory<u32> _activeTransitions; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
    }
}