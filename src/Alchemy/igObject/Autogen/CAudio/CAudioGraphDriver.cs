namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CAudioGraphDriver : igObject
    {
        [FieldAttr(16)] public CAudioGraphDriverModeList? _modes;
        [FieldAttr(24)] public CAudioGraphList? _affectedGraphs;
        [FieldAttr(32, false)] public CAudioGraphDriverMode? _currentMode;
        [FieldAttr(40)] public float _lastInput;
    }
}
