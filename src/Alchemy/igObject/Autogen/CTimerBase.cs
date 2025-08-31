namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CTimerBase : igObject
    {
        [FieldAttr(16)] public igTimeMetaField _startTime = new();
        [FieldAttr(20)] public igTimeMetaField _stopTime = new();
        [FieldAttr(24)] public bool _isRunning;
        [FieldAttr(25)] public bool _isPaused;
    }
}
