namespace Alchemy
{
    [ObjectAttr(240, 16)]
    public class igVfxBolt : igVfxRuntimeObject
    {
        public enum ECullType : uint
        {
            kCullNone = 0,
            kCullDefault = 1,
            kCullSoft = 2,
            kCullHard = 4,
            kCullPause = 8,
            kCullAll = 14,
        }

        [ObjectAttr(4)]
        public class BoltFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _flip;
            [FieldAttr(1, size: 1)] public bool _hasUpdated;
            [FieldAttr(2, size: 1)] public bool _teleported;
            [FieldAttr(3, size: 1)] public bool _isValid = false;
            [FieldAttr(4, size: 1)] public bool _isVisible = false;
            [FieldAttr(5, size: 1)] public bool _keepScale = false;
            [FieldAttr(6, size: 1)] public bool _lateUpdate = false;
        }

        [FieldAttr(16)] public igMatrix44fMetaField _matrix = new();
        [FieldAttr(80)] public igQuaternionFramefMetaField _frame = new();
        [FieldAttr(112)] public igQuaternionFramefMetaField _inverseFrame = new();
        [FieldAttr(144)] public igVec3fAlignedMetaField _velocity = new();
        [FieldAttr(160)] public igVec3fAlignedMetaField _spin = new();
        [FieldAttr(176)] public igVec3fMetaField _size = new();
        [FieldAttr(188)] public float _scale = 1.0f;
        [FieldAttr(192)] public igVec4fMetaField _color = new();
        [FieldAttr(208)] public igVec4fMetaField _parameters = new();
        [FieldAttr(224)] public igVfxBaseVariable? _variables;
        [FieldAttr(232)] public BoltFlags _boltFlags = new();
    }
}
