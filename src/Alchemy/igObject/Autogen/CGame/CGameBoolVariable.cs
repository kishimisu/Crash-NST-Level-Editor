namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGameBoolVariable : CGameVariable
    {
        [FieldAttr(24)] public bool _defaultValue;
        [FieldAttr(32)] public COnGameBoolVariableChangedDelegate? _onGameBoolVariableChanged;
        [FieldAttr(40)] public COnGameBoolVariableChangeEventList? _onGameBoolVariableChangedEventList;
    }
}
