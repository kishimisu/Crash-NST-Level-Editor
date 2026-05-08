namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class CRespawnTriggerComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24, ctr: 16)] public CQueryFilter? _queryFilter;
        [FieldAttr(nst: 32, ctr: 24)] public CPlayerRespawnComponent.ERespawnType _respawnType;
        [FieldAttr(nst: 36)] public CPlayerRespawnComponent.EPointSelectionMethod _pointSelectionMethod;
        [FieldAttr(nst: 40, ctr: 32)] public CPlayerStartEntityHandleList? _respawnPoints;
    }
}
