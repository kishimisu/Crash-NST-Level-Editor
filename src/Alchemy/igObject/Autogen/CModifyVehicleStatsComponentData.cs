namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CModifyVehicleStatsComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CVehicleStats? _stats;
        [FieldAttr(32)] public EVehicleStatSource _source = EVehicleStatSource.eVSS_TemporaryBoost;
    }
}
