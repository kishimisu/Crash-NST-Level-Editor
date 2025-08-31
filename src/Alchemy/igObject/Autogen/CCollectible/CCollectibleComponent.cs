namespace Alchemy
{
    [ObjectAttr(200, 8)]
    public class CCollectibleComponent : igComponent
    {
        [FieldAttr(40)] public COnCollectibleComponentCollectedDelegate? _onCollectBegin;
        [FieldAttr(48)] public COnCollectibleComponentCollectedEventList? _onCollectBeginEventList;
        [FieldAttr(56)] public COnCollectibleComponentCollectedDelegate? _onCollected;
        [FieldAttr(64)] public COnCollectibleComponentCollectedEventList? _onCollectedEventList;
        [FieldAttr(72)] public float _autoCollectTime = -1.0f;
        [FieldAttr(76)] public float _notCollectibleUntilTime;
        [FieldAttr(80)] public float _attractSpeed;
        [FieldAttr(84)] public float _startingZPosition;
        [FieldAttr(88)] public bool _watchToDisablePhysics;
        [FieldAttr(89)] public bool _forceAutoCollect;
        [FieldAttr(90)] public bool _collectionPaused;
        [FieldAttr(91)] public bool _attracting;
        [FieldAttr(92)] public bool _useAttractTargetPosition;
        [FieldAttr(96)] public igHandleMetaField _attractToActor = new();
        [FieldAttr(104)] public float _distanceWhenAttractionBegan;
        [FieldAttr(108)] public float _scaleWhenAttractionBegan;
        [FieldAttr(112)] public igVec3fMetaField _attractTargetPosition = new();
        [FieldAttr(124)] public float _attractRadiusWorldModifier = -1.0f;
        [FieldAttr(128)] public float _awardValueWorldModifier = -1.0f;
        [FieldAttr(132)] public float _alternateAwardValueWorldModifier = -1.0f;
        [FieldAttr(136)] public igHandleMetaField _idleVfx = new();
        [FieldAttr(144)] public igHandleMetaField _trailVfx = new();
        [FieldAttr(152)] public igHandleMetaField _collectBeginVfx = new();
        [FieldAttr(160)] public CHavokShapeMetaField _sphereShape = new();
        [FieldAttr(168)] public CHavokRigidBodyMetaField _rigidBody = new();
        [FieldAttr(184)] public CWorldCollectibleModifierItem? _modifierItem;
        [FieldAttr(192)] public bool _useAlternateAwardValue;
    }
}
