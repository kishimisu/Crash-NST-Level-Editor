namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGameFloatVariable : CGameVariable
    {
        [FieldAttr(24)] public float _defaultValue;
        [FieldAttr(32)] public COnGameFloatVariableChangedDelegate? _onGameFloatVariableChanged;
        [FieldAttr(40)] public COnGameFloatVariableChangeEventList? _onGameFloatVariableChangedEventList;
    }
}
