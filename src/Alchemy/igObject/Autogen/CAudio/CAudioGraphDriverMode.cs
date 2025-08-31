namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CAudioGraphDriverMode : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _activateOneShotSound = new();
        [FieldAttr(24)] public igHandleMetaField _deactivateOneShotSound = new();
        [FieldAttr(32)] public igHandleMetaField _whileActiveLoopingSound = new();
        [FieldAttr(40)] public igHandleMetaField _playingLoopingSound = new();
        [FieldAttr(48)] public bool _isAlreadyUsed;
    }
}
