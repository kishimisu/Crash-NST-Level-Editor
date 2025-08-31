namespace Alchemy
{
    [ObjectAttr(80, 4)]
    public class CNavPowerSettings : igObject
    {
        [FieldAttr(16)] public uint _layer;
        [FieldAttr(20)] public float _voxelSize = 12.0f;
        [FieldAttr(24)] public float _verticalOffset = 12.0f;
        [FieldAttr(28)] public float _characterRadius = 50.0f;
        [FieldAttr(32)] public float _characterHeight = 250.0f;
        [FieldAttr(36)] public float _dropOffRadius = 50.0f;
        [FieldAttr(40)] public float _stepHeight = 16.0f;
        [FieldAttr(44)] public float _maxWalkableSlope = 45.0f;
        [FieldAttr(48)] public bool _optimizeForAxisAligned;
        [FieldAttr(49)] public bool _useEnhancedTerrainTracking;
        [FieldAttr(50)] public bool _enableLinkGeneration = true;
        [FieldAttr(52)] public float _linkMinConnectDistance;
        [FieldAttr(56)] public float _linkMaxConnectDistance = 150.0f;
        [FieldAttr(60)] public float _linkMaxJumpUpDistance = 300.0f;
        [FieldAttr(64)] public float _linkMaxJumpDownDistance = 750.0f;
        [FieldAttr(68)] public float _linkMaxConnectAngle = 60.0f;
        [FieldAttr(72)] public float _linkProbeHeight = 200.0f;
        [FieldAttr(76)] public float _linkHighJumpThreshold = 175.0f;
    }
}
