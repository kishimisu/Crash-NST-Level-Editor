namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class igVfxPrimitive : igVfxRuntimeObject
    {
        [ObjectAttr(4)]
        public class PrimitiveFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isCulled;
            [FieldAttr(1, size: 1)] public bool _isAlive;
            [FieldAttr(2, size: 1)] public bool _isPaused;
            [FieldAttr(3, size: 1)] public bool _lateUpdate;
            [FieldAttr(4, size: 13)] public int _instanceCount;
            [FieldAttr(17, size: 8)] public u8 _spawnGroup;
            [FieldAttr(25, size: 2)] public u8 _cameraIndex;
            [FieldAttr(27, size: 1)] public bool _wasCulled;
        }

        [FieldAttr(16)] public igVfxPrimitiveData? _source;
        [FieldAttr(24)] public igRawRefMetaField _instanceHead = new();
        [FieldAttr(32)] public igRawRefMetaField _instanceTail = new();
        [FieldAttr(40, false)] public igVfxPrimitive? _primNext;
        [FieldAttr(48)] public PrimitiveFlags _primitiveFlags = new();
        [FieldAttr(52)] public igStatHandleMetaField _instanceCountStat = new();
        [FieldAttr(56)] public igStatHandleMetaField _primitiveCountStat = new();
        [FieldAttr(60)] public float _timeScale = 1.0f;
        [FieldAttr(64)] public float _budgetScale;
        [FieldAttr(72, false)] public igVfxPrimitive? _dependency;
        [FieldAttr(80)] public uint _lastUpdateFrame;
        [FieldAttr(84)] public u16 _layer = 65535;
        [FieldAttr(88)] public igRandomMetaField _rng = new();
        [FieldAttr(96, false)] public igVfxSpawnRate? _spawnRate;
    }
}
