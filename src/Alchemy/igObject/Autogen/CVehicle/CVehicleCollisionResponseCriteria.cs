namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class CVehicleCollisionResponseCriteria : igNamedObject
    {
        [FieldAttr(24)] public bool _isEnabled = true;
        [FieldAttr(28)] public float _sourceMinSpeedRatio = -10.0f;
        [FieldAttr(32)] public float _sourceMaxSpeedRatio = 10.0f;
        [FieldAttr(36)] public float _targetMinSpeedRatio = -10.0f;
        [FieldAttr(40)] public float _targetMaxSpeedRatio = 10.0f;
        [FieldAttr(44)] public float _combinedMinSpeedRatio = -10.0f;
        [FieldAttr(48)] public float _combinedMaxSpeedRatio = 10.0f;
        [FieldAttr(52)] public float _minWeightDiff = -500.0f;
        [FieldAttr(56)] public float _maxWeightDiff = 500.0f;
        [FieldAttr(60)] public i16 _priority;
        [FieldAttr(64)] public EVehicleCollisionTriState _worldCollision;
        [FieldAttr(68)] public EVehicleCollisionTriState _levelBorderCollision;
        [FieldAttr(72)] public EVehicleCollisionTriState _destructibleCollision = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(76)] public uint _teamRelationship = 7;
        [FieldAttr(80)] public EVehicleCollisionCriteriaOwner _criteriaOwner;
        [FieldAttr(84)] public EVehicleCollisionTriState _blockingCollision = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(88)] public EVehicleCollisionTriState _sourceDriftingIntoCollision = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(92)] public EVehicleCollisionTriState _sourceIsPlayer = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(96)] public EVehicleCollisionTriState _sourceIsVehicle = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(100)] public EVehicleCollisionTriState _sourceIsOnSurface = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(104)] public EVehicleCollisionTriState _sourceIsOnSpline;
        [FieldAttr(108)] public EVehicleCollisionTriState _targetIsPlayer = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(112)] public EVehicleCollisionTriState _targetDriftingIntoCollision = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(116)] public EVehicleCollisionTriState _targetIsVehicle = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(120)] public EVehicleCollisionTriState _targetIsOnSurface = EVehicleCollisionTriState.eVCTS_Either;
        [FieldAttr(124)] public EVehicleCollisionTriState _targetIsOnSpline;
        [FieldAttr(128)] public EVehicleCollisionWeightClassRelationship _weightClassRelationship = EVehicleCollisionWeightClassRelationship.eVCWC_All;
        [FieldAttr(136)] public CVehicleCollisionResponse? _sourceResponse;
        [FieldAttr(144)] public CVehicleCollisionResponse? _targetResponse;
        [FieldAttr(152)] public float _sourceMinForwardDot = 2.0f;
        [FieldAttr(156)] public float _sourceMaxForwardDot = -2.0f;
        [FieldAttr(160)] public float _sourceMinWorldZDot = 2.0f;
        [FieldAttr(164)] public float _sourceMaxWorldZDot = -2.0f;
        [FieldAttr(168)] public float _targetMinForwardDot = 2.0f;
        [FieldAttr(172)] public float _targetMaxForwardDot = -2.0f;
        [FieldAttr(176)] public float _targetMinWorldZDot = 2.0f;
        [FieldAttr(180)] public float _targetMaxWorldZDot = -2.0f;
    }
}
