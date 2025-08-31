namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igEntity : igObject
    {
        public enum ENetworkSpawnAuthority : uint
        {
            kLocalAuthority = 0,
            kHostAuthority = 1,
            kNoAuthority = 2,
            kParentAuthority = 3,
        }

        [ObjectAttr(4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _canSpawn = true;
            [FieldAttr(1, size: 1)] public bool _isArchetype;
            [FieldAttr(2, size: 1)] public bool _spawned;
            [FieldAttr(3, size: 4)] public uint _disableStack;
            [FieldAttr(7, size: 1)] public bool _enabledByVisualScript = false;
            [FieldAttr(8, size: 1)] public bool _enabled;
            [FieldAttr(9, size: 1)] public bool _isFading;
            [FieldAttr(10, size: 1)] public bool _isPositionDirty;
            [FieldAttr(11, size: 1)] public bool _isRotationDirty;
            [FieldAttr(12, size: 1)] public bool _isScaleDirty;
            [FieldAttr(13, size: 1)] public bool _isMoving;
            [FieldAttr(14, size: 1)] public bool _isVisible;
            [FieldAttr(15, size: 1)] public bool _isHidden;
            [FieldAttr(16, size: 1)] public bool _isVolumeCulled = false;
            [FieldAttr(17, size: 1)] public bool _canVolumeCull = false;
            [FieldAttr(18, size: 5)] public uint _disableVolumeCullStack;
            [FieldAttr(23, size: 1)] public bool _disableVolumeCullByScript;
            [FieldAttr(24, size: 1)] public bool _netHasAuthority = false;
            [FieldAttr(25, size: 7)] public int _userFlags;
        }

        [FieldAttr(16)] public igEntityBolt? _bolt;
        [FieldAttr(24)] public igComponentList? _components;
        [FieldAttr(32)] public igVec3fMetaField _parentSpacePosition = new();
        [FieldAttr(48)] public igEntityTransform? _transform;
        [FieldAttr(56)] public Bitfield _bitfield = new();
        [FieldAttr(64)] public igEntityData? _entityData;
    }
}
