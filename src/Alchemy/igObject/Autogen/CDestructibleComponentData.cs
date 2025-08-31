namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CDestructibleComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public string? _acceptAttackIdentifier = null;
        [FieldAttr(32)] public CDestructibleStageList? _stages;
    }
}
