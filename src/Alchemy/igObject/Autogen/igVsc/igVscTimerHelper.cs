namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscTimerHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _timer;
        [FieldAttr(24)] public igVscObjectAccessor? _updater;
        [FieldAttr(32)] public igVscFloatAccessor? _duration;
        [FieldAttr(40)] public igVscBoolAccessor? _resetOnStart;
        [FieldAttr(48)] public igVscFloatAccessor? _timeToAdd;
        [FieldAttr(56, false)] public igVscMethod? _finished;
        [FieldAttr(64, false)] public igVscMethod? _aborted;
        [FieldAttr(72)] public igVscMethod? _remaining;
    }
}
