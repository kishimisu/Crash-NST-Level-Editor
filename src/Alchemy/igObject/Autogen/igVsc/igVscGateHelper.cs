namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscGateHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _gate;
        [FieldAttr(24)] public igVscBoolAccessor? _startOpen;
        [FieldAttr(32)] public igVscIntAccessor? _autoCloseCount;
        [FieldAttr(40, false)] public igVscActionNode? _isOpen;
        [FieldAttr(48, false)] public igVscActionNode? _isClosed;
    }
}
