namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CFilterByTeam : CFilterMethod
    {
        [FieldAttr(24)] public CEntityData.EEntityTeam _team;
    }
}
