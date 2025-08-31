namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CAISystemData : igSingleton
    {
        [FieldAttr(16)] public float _interiorCombatCircleDistance = 150.0f;
        [FieldAttr(20)] public float _exteriorCombatCircleDistance = 400.0f;
        [FieldAttr(24)] public int _maxInteriorEnemies = 3;
        [FieldAttr(28)] public float _interiorCombatCircleDistanceVehicle = 500.0f;
        [FieldAttr(32)] public float _exteriorCombatCircleDistanceVehicle = 1000.0f;
        [FieldAttr(36)] public int _maxInteriorEnemiesVehicle = 3;
        [FieldAttr(40)] public float _interiorBufferAngle = 10.0f;
        [FieldAttr(44)] public float _defaultAwarenessRadius = 1500.0f;
        [FieldAttr(48)] public float _defaultVehicleAwarenessRadius = 5000.0f;
        [FieldAttr(52)] public float _defaultUnawarenessBuffer = 1000.0f;
        [FieldAttr(56)] public float _distancePenalty = 1.0f;
        [FieldAttr(60)] public float _enemyPenalty = 1000.0f;
        [FieldAttr(64)] public float _interiorEnemyPenalty = 1.0f;
        [FieldAttr(68)] public float _playerBonus = 1000.0f;
        [FieldAttr(72)] public CDamageData? _defaultMeleeDeflectionDamage;
        [FieldAttr(80)] public CAIAttackCoordinatorData? _attackCoordinatorData;
        [FieldAttr(88)] public CMapToEnemyTable? _mapToEnemyTable;
        [FieldAttr(96)] public float _debugSpawnOffset = 100.0f;
    }
}
