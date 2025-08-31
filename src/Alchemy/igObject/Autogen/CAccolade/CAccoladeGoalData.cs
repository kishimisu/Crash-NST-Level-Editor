namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CAccoladeGoalData : igObject
    {
        [FieldAttr(16)] public uint _numberOfCompletions = 1;
        [FieldAttr(24)] public string? _steamStatId = "";
    }
}
