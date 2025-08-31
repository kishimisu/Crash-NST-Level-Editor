namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CTriggerVolumeComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igVec3fMetaField _offset = new();
        [FieldAttr(36)] public igVec3fMetaField _rotation = new();
        [FieldAttr(48)] public CQueryFilter? _queryFilter;
        [FieldAttr(56)] public uint _collisionFlags = 31;
        [FieldAttr(60)] public ETriggerVolumeQualityType _qualityType = ETriggerVolumeQualityType.eTVCF_Keyframed_DynamicsOnly;
        [FieldAttr(64)] public ETriggerVolumeDetectionType _detectionType = ETriggerVolumeDetectionType.eTVDT_Normal;
        [FieldAttr(68)] public bool _sendEventsToEntity = true;
        [FieldAttr(69)] public bool _triggerCausesTouch = true;
        [FieldAttr(70)] public bool _triggerCausesAct;
        [FieldAttr(71)] public bool _processMagicMoment;
        [FieldAttr(72)] public bool _triggerForOpponentsOnly;
        [FieldAttr(73)] public bool _singleFire;
        [FieldAttr(74)] public bool _networkEnabled;
    }
}
