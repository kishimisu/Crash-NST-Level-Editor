namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVfxPrimitiveData : igObject
    {
        public enum ESubframeSpawn : uint
        {
            kIncludeLastFrame = 0,
            kIncludeCurrentFrame = 1,
            kIncludeBothFrames = 2,
            kUseLastFrame = 3,
            kUseCurrentFrame = 4,
        }

        [ObjectAttr(2)]
        public class DeviceLayers : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _deviceLayer1 = true;
            [FieldAttr(1, size: 1)] public bool _deviceLayer2 = false;
            [FieldAttr(2, size: 1)] public bool _deviceLayer3 = false;
            [FieldAttr(3, size: 1)] public bool _deviceLayer4 = false;
            [FieldAttr(4, size: 1)] public bool _deviceLayer5 = false;
            [FieldAttr(5, size: 11)] public uint _overheadCost;
        }

        [ObjectAttr(2)]
        public class SpawnLayers : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _spawnLayer1 = true;
            [FieldAttr(1, size: 1)] public bool _spawnLayer2 = false;
            [FieldAttr(2, size: 1)] public bool _spawnLayer3 = false;
            [FieldAttr(3, size: 1)] public bool _spawnLayer4 = false;
            [FieldAttr(4, size: 1)] public bool _spawnLayer5 = false;
            [FieldAttr(5, size: 1)] public bool _spawnLayer6 = false;
            [FieldAttr(6, size: 1)] public bool _spawnLayer7 = false;
            [FieldAttr(7, size: 1)] public bool _spawnLayer8 = false;
            [FieldAttr(8, size: 1)] public bool _spawnLayer9 = false;
            [FieldAttr(9, size: 1)] public bool _spawnLayer10 = false;
            [FieldAttr(10, size: 1)] public bool _spawnLayer11 = false;
            [FieldAttr(11, size: 1)] public bool _spawnLayer12 = false;
            [FieldAttr(12, size: 1)] public bool _spawnLayer13 = false;
            [FieldAttr(13, size: 1)] public bool _spawnLayer14 = false;
            [FieldAttr(14, size: 1)] public bool _spawnLayer15 = false;
            [FieldAttr(15, size: 1)] public bool _spawnLayer16 = false;
        }

        [ObjectAttr(4)]
        public class PrimitiveFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isVisible = true;
            [FieldAttr(1, size: 1)] public bool _infiniteInstanceLifeSpan;
            [FieldAttr(2, size: 1)] public bool _killOnLoopOut;
            [FieldAttr(3, size: 3)] public igVfxPrimitiveData.ESubframeSpawn _subframeSpawn;
            [FieldAttr(6, size: 1)] public bool _dataFieldsCached;
            [FieldAttr(7, size: 12)] public uint _primitiveRefCount;
            [FieldAttr(19, size: 1)] public bool _forceBoltInputs;
        }

        [FieldAttr(16)] public igHandleMetaField _deathFx = new();
        [FieldAttr(24)] public igTimeMetaField _spawnTime = new();
        [FieldAttr(28)] public float _lifeSpan = 1.0f;
        [FieldAttr(32)] public igRangedFloatMetaField _instanceLifeSpan = new();
        [FieldAttr(40)] public igVfxSpawnRateData? _spawnRate;
        [FieldAttr(48)] public DeviceLayers _deviceLayers = new();
        [FieldAttr(50)] public SpawnLayers _spawnLayers = new();
        [FieldAttr(52)] public PrimitiveFlags _primitiveFlags = new();
    }
}
