namespace Alchemy
{
    [ObjectAttr(304, 16)]
    public class CHavokQuery : igObject
    {
        [FieldAttr(16)] public uint _cachedCollisionCount = 4294967295;
        [FieldAttr(24)] public u32 /* igStructMetaField */ _cachedCollision;
        [FieldAttr(104)] public CObjectBolt? _sourceBolt;
        [FieldAttr(112)] public CObjectBolt? _targetBolt;
        [FieldAttr(128)] public u32 /* igStructMetaField */ _sourceOffsetVector;
        [FieldAttr(144)] public u32 /* igStructMetaField */ _targetOffsetVector;
        [FieldAttr(160)] public igHandleMetaField _filterEntity = new();
        [FieldAttr(168)] public uint _collisionFilterInfo = 1092550660;
        [FieldAttr(172)] public float _radius;
        [FieldAttr(176)] public bool _useSourceEntityCollisionShape;
        [FieldAttr(177)] public bool _runOnce = true;
        [FieldAttr(178)] public bool _ignoreSourceEntityCollision = true;
        [FieldAttr(179)] public bool _drawDebug;
        [FieldAttr(180)] public bool _useCaching = true;
        [FieldAttr(181)] public bool _reverseDirection;
        [FieldAttr(184)] public u32 /* igStructMetaField */ _shape;
        [FieldAttr(192)] public bool _useSourceEntityCollisionFiltering;
        [FieldAttr(193)] public bool _useSourceEntityCollisionFilterAsMask;
        [FieldAttr(200)] public igHandleMetaField _collisionFilteringSource = new();
        [FieldAttr(208)] public u64 _poolAllocationID;
        [FieldAttr(216)] public bool _isPaused;
        [FieldAttr(217)] public bool _useSourceCenter;
        [FieldAttr(218)] public bool _useTargetCenter;
        [FieldAttr(219)] public bool _useSourceBolt;
        [FieldAttr(220)] public bool _useTargetBolt;
        [FieldAttr(224)] public igHandleMetaField _sourceBoltPoint = new();
        [FieldAttr(232)] public igHandleMetaField _targetBoltPoint = new();
        [FieldAttr(240)] public EHavokQueryType _queryType;
        [FieldAttr(244)] public EHavokQuerySubType _querySubType;
        [FieldAttr(248)] public EHavokQueryKillReason _killReason;
        [FieldAttr(252)] public u8 _resultCount = 1;
        [FieldAttr(253)] public bool _alwaysFindClosestHit = true;
        [FieldAttr(254)] public bool _oneHitPerBody;
        [FieldAttr(256)] public igRawRefMetaField _collisionCallback = new();
        [FieldAttr(264)] public igHandleMetaField _collisionCallbackUserData = new();
        [FieldAttr(272)] public igRawRefMetaField _killCallback = new();
        [FieldAttr(280)] public igHandleMetaField _killCallbackUserData = new();
        [FieldAttr(288)] public float _pathOffsetMeters;
    }
}
