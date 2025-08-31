namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CSoundEventData : igObject
    {
        [FieldAttr(16)] public string? mSound = null;
        [FieldAttr(24)] public string? mAttackSound = null;
        [FieldAttr(32)] public string? mRolloffSound = null;
        [FieldAttr(40)] public igHandleMetaField _soundHandle = new();
        [FieldAttr(48)] public igHandleMetaField _attackSoundHandle = new();
        [FieldAttr(56)] public igHandleMetaField _rolloffSoundHandle = new();
        [FieldAttr(64)] public ESoundLoopEvent _loopEvent;
        [FieldAttr(68)] public bool _findSoundOnThisVehicleDriver;
        [FieldAttr(72)] public CSoundUpdateMethodList? _updateMethodList;
    }
}
