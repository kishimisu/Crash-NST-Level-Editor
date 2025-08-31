namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CEntity : igEntity
    {
        public enum EScaleSource : uint
        {
            eSS_Entity = 0,
            eSS_EntityData = 1,
        }

        [ObjectAttr(2)]
        public class Properties : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _startHidden;
            [FieldAttr(1, size: 1)] public bool _haveComponentsToStart;
            [FieldAttr(2, size: 1)] public bool _haveComponentsToRemove;
            [FieldAttr(3, size: 1)] public bool _actEnabled;
            [FieldAttr(4, size: 1)] public bool _actToggleOn = false;
            [FieldAttr(5, size: 1)] public CEntity.EScaleSource _scaleSource;
            [FieldAttr(6, size: 1)] public bool netReplicate;
            [FieldAttr(7, size: 1)] public bool hasTimeComponent;
            [FieldAttr(8, size: 1)] public bool hasScaledTimeComponent;
            [FieldAttr(9, size: 1)] public bool _netShouldSyncOnJip;
            [FieldAttr(10, size: 1)] public bool _teamIsDirty;
        }

        [FieldAttr(72)] public igVec3fMetaField _min = new();
        [FieldAttr(84)] public igVec3fMetaField _max = new();
        [FieldAttr(96)] public igVec3fMetaField _velocity = new();
        [FieldAttr(108)] public igVec3fMetaField _angularVelocity = new();
        [FieldAttr(120)] public u32 /* igStructMetaField */ _flags;
        [FieldAttr(128)] public string? _name = null;
        [FieldAttr(136)] public CEntityIDMetaField _id = new();
        [FieldAttr(140)] public Properties _properties = new();
        [FieldAttr(142)] public i16 _turningLockedCounter;
    }
}
