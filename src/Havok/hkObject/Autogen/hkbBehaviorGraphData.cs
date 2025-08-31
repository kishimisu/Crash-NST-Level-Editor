using Alchemy;

namespace Havok
{
    [ObjectAttr(112)]
    public class hkbBehaviorGraphData : hkReferencedObject
    {
        public override uint Hash => 0x907a8222;

        [FieldAttr(16)] public hkMemory<float> _attributeDefaults; // TYPE_ARRAY, subtype: TYPE_REAL
        [FieldAttr(32)] public hkMemory<hkbVariableInfo> _variableInfos; // TYPE_ARRAY, ctype: hkbVariableInfo, subtype: TYPE_STRUCT
        [FieldAttr(48)] public hkMemory<hkbVariableInfo> _characterPropertyInfos; // TYPE_ARRAY, ctype: hkbVariableInfo, subtype: TYPE_STRUCT
        [FieldAttr(64)] public hkMemory<hkbEventInfo> _eventInfos; // TYPE_ARRAY, ctype: hkbEventInfo, subtype: TYPE_STRUCT
        [FieldAttr(80)] public hkMemory<hkbVariableBounds> _variableBounds; // TYPE_ARRAY, ctype: hkbVariableBounds, subtype: TYPE_STRUCT
        [FieldAttr(96)] public hkbVariableValueSet _variableInitialValues; // TYPE_POINTER, ctype: hkbVariableValueSet, subtype: TYPE_STRUCT
        [FieldAttr(104)] public hkbBehaviorGraphStringData _stringData; // TYPE_POINTER, ctype: hkbBehaviorGraphStringData, subtype: TYPE_STRUCT
    }
}