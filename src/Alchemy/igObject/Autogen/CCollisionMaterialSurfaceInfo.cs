namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CCollisionMaterialSurfaceInfo : igObject
    {
        [ObjectAttr(2)]
        public class SpawnLayers : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _spawnLayer1 = true;
            [FieldAttr(1, size: 1)] public bool _spawnLayer2;
            [FieldAttr(2, size: 1)] public bool _spawnLayer3;
            [FieldAttr(3, size: 1)] public bool _spawnLayer4;
            [FieldAttr(4, size: 1)] public bool _spawnLayer5;
            [FieldAttr(5, size: 1)] public bool _spawnLayer6;
            [FieldAttr(6, size: 1)] public bool _spawnLayer7;
            [FieldAttr(7, size: 1)] public bool _spawnLayer8;
            [FieldAttr(8, size: 1)] public bool _spawnLayer9;
            [FieldAttr(9, size: 1)] public bool _spawnLayer10;
            [FieldAttr(10, size: 1)] public bool _spawnLayer11;
            [FieldAttr(11, size: 1)] public bool _spawnLayer12;
            [FieldAttr(12, size: 1)] public bool _spawnLayer13;
            [FieldAttr(13, size: 1)] public bool _spawnLayer14;
            [FieldAttr(14, size: 1)] public bool _spawnLayer15;
            [FieldAttr(15, size: 1)] public bool _spawnLayer16;
        }

        [ObjectAttr(2)]
        public class SurfaceFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _preventRunning;
            [FieldAttr(1, size: 1)] public bool _ripplingSurface;
            [FieldAttr(2, size: 1)] public bool _queryOnly;
            [FieldAttr(3, size: 1)] public bool _deepWater;
            [FieldAttr(4, size: 1)] public bool _chasm;
            [FieldAttr(5, size: 1)] public bool _preventJumping;
            [FieldAttr(6, size: 1)] public bool _ignoreVehicleBlockingContacts;
            [FieldAttr(7, size: 1)] public bool _forceVehicleBlockingContacts;
            [FieldAttr(8, size: 1)] public bool _actionPackGroundIgnoreBlocking = false;
        }

        [FieldAttr(16)] public string? _soundName = null;
        [FieldAttr(24)] public string? _vehicleLandingSoundName = null;
        [FieldAttr(32)] public SpawnLayers _spawnLayers = new();
        [FieldAttr(34)] public SurfaceFlags _surfaceFlags = new();
        [FieldAttr(40)] public CSurfaceMotion? _surfaceMotion;
        [FieldAttr(48)] public float _speedMultiplier = 1.0f;
        [FieldAttr(52)] public float _slipperyMultiplier = 1.0f;
        [FieldAttr(56)] public float _traction = 1.0f;
        [FieldAttr(60)] public float _slipperyFactor;
        [FieldAttr(64)] public float _slipperyFactorAcceleration;
    }
}
