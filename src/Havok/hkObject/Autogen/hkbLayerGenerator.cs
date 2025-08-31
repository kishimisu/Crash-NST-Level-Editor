using Alchemy;

namespace Havok
{
    [ObjectAttr(184)]
    public class hkbLayerGenerator : hkbGenerator
    {
        public override uint Hash => 0xb4e0c52f;

        [FieldAttr(136)] public hkMemoryPtr<hkbLayer> _layers; // TYPE_ARRAY, ctype: hkbLayer, subtype: TYPE_POINTER
        [FieldAttr(152)] public i16 _indexOfSyncMasterChild; // TYPE_INT16
        [FieldAttr(154)] public u16 _flags; // TYPE_FLAGS, etype: LayerFlagBits, subtype: TYPE_UINT16
        [FieldAttr(156)] public i32 _numActiveLayers; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(160)] public hkMemory<u32> _layerInternalStates; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(176)] public bool _initSync; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}