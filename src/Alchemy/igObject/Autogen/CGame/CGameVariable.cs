namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CGameVariable : igObject
    {
        public enum EGameVariableLifetime : uint
        {
            eGVL_Saved = 0,
            eGVL_Session = 1,
            eGVL_Level = 2,
        }

        [FieldAttr(16)] public EGameVariableLifetime _variableLifetime;
        [FieldAttr(20)] public bool _replicated = true;
        [FieldAttr(21)] public bool _triggerAutoSave = true;
    }
}
