namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVehicleStatsComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CVehicleStats? _baseStats;
    }
}
