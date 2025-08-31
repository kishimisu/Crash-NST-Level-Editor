using Alchemy;

namespace Havok
{
    [ObjectAttr(432)]
    public class hkbBehaviorGraph : hkbGenerator
    {
        public override uint Hash => 0xfdedb83b;

        [FieldAttr(136)] public EVariableMode _variableMode; // TYPE_ENUM, etype: VariableMode, subtype: TYPE_INT8
        [FieldAttr(144)] public hkMemory<u32> _uniqueIdPool; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(160)] public u32 _idToStateMachineTemplateMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(168)] public hkMemory<u32> _mirroredExternalIdMap; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(184)] public u32 _pseudoRandomGenerator; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(192)] public hkbGenerator _rootGenerator; // TYPE_POINTER, ctype: hkbGenerator, subtype: TYPE_STRUCT
        [FieldAttr(200)] public hkbBehaviorGraphData _data; // TYPE_POINTER, ctype: hkbBehaviorGraphData, subtype: TYPE_STRUCT
        [FieldAttr(208)] public u32 _template; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(216)] public u32 _rootGeneratorClone; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(224)] public u32 _activeNodes; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(232)] public u32 _globalTransitionData; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(240)] public u32 _eventIdMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(248)] public u32 _attributeIdMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(256)] public u32 _variableIdMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(264)] public u32 _characterPropertyIdMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(272)] public u32 _variableValueSet; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(280)] public u32 _nodeTemplateToCloneMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(288)] public u32 _stateListenerTemplateToCloneMap; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(296)] public hkMemory<u32> _recentlyCreatedClones; // TYPE_ARRAY, subtype: TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(312)] public u32 _nodePartitionInfo; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(320)] public i32 _numIntermediateOutputs; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(328)] public hkMemory<u32> _intermediateOutputSizes; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(344)] public hkMemory<u32> _jobs; // TYPE_ARRAY, subtype: TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(360)] public hkMemory<u32> _allPartitionMemory; // TYPE_ARRAY, subtype: TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(376)] public hkMemory<u32> _internalToRootVariableIdMap; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(392)] public hkMemory<u32> _internalToCharacterCharacterPropertyIdMap; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(408)] public hkMemory<u32> _internalToRootAttributeIdMap; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(424)] public u16 _nextUniqueId; // TYPE_UINT16, flags: SERIALIZE_IGNORED
        [FieldAttr(426)] public bool _isActive; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(427)] public bool _isLinked; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(428)] public bool _updateActiveNodes; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(429)] public bool _updateActiveNodesForEnable; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(430)] public bool _checkNodeValidity; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(431)] public bool _stateOrTransitionChanged; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}