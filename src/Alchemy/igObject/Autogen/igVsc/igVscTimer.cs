namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(igUpdateable))]
    public class igVscTimer : igUpdateable
    {
        [FieldAttr(32)] public igHandleMetaField _delegateThis = new();
        [FieldAttr(40)] public igHandleMetaField _finishedDelegate = new();
        [FieldAttr(48)] public igHandleMetaField _abortedDelegate = new();
        [FieldAttr(56)] public igHandleMetaField _remainingDelegate = new();
        [FieldAttr(64)] public igHandleMetaField _updater = new();
        [FieldAttr(72)] public float _duration;
        [FieldAttr(76)] public bool _resetOnStart;
        [FieldAttr(77)] public bool _isRunning;
        [FieldAttr(80)] public float _timeRemaining;
    }
}
