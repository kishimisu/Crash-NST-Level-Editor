namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGameIntVariable : CGameVariable
    {
        [FieldAttr(24)] public int _defaultValue;
        [FieldAttr(32)] public COnGameIntVariableChangedDelegate? _onGameIntVariableChanged;
        [FieldAttr(40)] public COnGameIntVariableChangeEventList? _onGameIntVariableChangedEventList;
    }
}
