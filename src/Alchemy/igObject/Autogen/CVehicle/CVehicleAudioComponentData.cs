namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CVehicleAudioComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CAudioGraphDriverList? _driverList;
        [FieldAttr(32)] public CAudioGraphDriverList? _nonLocalPlayerDriverList;
        [FieldAttr(40)] public CVehicleAudioCollisionDataList? _collisionDataList;
        [FieldAttr(48)] public CModSoundDataList? _modSoundDataList;
        [FieldAttr(56)] public igHandleMetaField _soundOnOneShot = new();
        [FieldAttr(64)] public igHandleMetaField _soundOffOneShot = new();
        [FieldAttr(72)] public igHandleMetaField _onGroundLoopingSound = new();
        [FieldAttr(80)] public igHandleMetaField _onWaterLoopingSound = new();
        [FieldAttr(88)] public igHandleMetaField _submergedLoopingSound = new();
        [FieldAttr(96)] public igHandleMetaField _onWaterNonLocalPlayerLoopingSound = new();
        [FieldAttr(104)] public igHandleMetaField _submergedNonLocalPlayerLoopingSound = new();
        [FieldAttr(112)] public bool _useRacingUpdateFrequency = true;
        [FieldAttr(113)] public bool _alwaysUpdateAudio = true;
    }
}
