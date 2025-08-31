namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igComponent : igObject
    {
        [ObjectAttr(4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isStarted;
            [FieldAttr(1, size: 1)] public bool _hasEverStarted;
            [FieldAttr(2, size: 1)] public bool _isThreadSafe;
            [FieldAttr(3, size: 1)] public bool _isCrashed;
            [FieldAttr(4, size: 1)] public bool _isPendingRemove;
            [FieldAttr(5, size: 1)] public bool _hasReceivedCreateMessage;
            [FieldAttr(6, size: 1)] public bool _enabled;
            [FieldAttr(7, size: 8)] public uint _disableStack;
            [FieldAttr(15, size: 1)] public bool _enabledByVisualScript = false;
            [FieldAttr(16, size: 1)] public bool _baseFunctionCalled;
            [FieldAttr(17, size: 15)] public int _userFlags;
        }

        [FieldAttr(16)] public igComponentData? _data;
        [FieldAttr(24, false)] public igEntity? _entity;
        [FieldAttr(32)] public Bitfield _bitfield = new();
    }
}
