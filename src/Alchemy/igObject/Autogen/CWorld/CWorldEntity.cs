namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CWorldEntity : CEntity
    {
        [FieldAttr(144)] public CWorldData? _worldData;
        [FieldAttr(152)] public igVec3fMetaField _extentMin = new();
        [FieldAttr(164)] public igVec3fMetaField _extentMax = new();
        [FieldAttr(176)] public igHandleMetaField _spawnedCameraEffect = new();
        [FieldAttr(184)] public bool _hasPoppedMagicMomentDisable;
        [FieldAttr(192)] public igHandleMetaField _movingPushblock = new();
        [FieldAttr(200)] public igHandleMetaField _surfaceVfxComponent = new();
        [FieldAttr(208)] public EWorldGameplayMode _currentGameplayMode;
    }
}
