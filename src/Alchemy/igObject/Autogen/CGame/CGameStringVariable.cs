namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGameStringVariable : CGameVariable
    {
        [FieldAttr(24)] public string? _defaultValue = null;
        [FieldAttr(32)] public COnGameStringVariableChangedDelegate? _onGameStringVariableChanged;
        [FieldAttr(40)] public COnGameStringVariableChangedEventList? _onGameStringVariableChangedEventList;
    }
}
