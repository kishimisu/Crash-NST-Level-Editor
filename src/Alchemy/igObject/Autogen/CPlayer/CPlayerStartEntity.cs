namespace Alchemy
{
    [ObjectAttr(176, 8)]
    public class CPlayerStartEntity : CEntity
    {
        [FieldAttr(144)] public bool _zoneStart;
        [FieldAttr(152)] public CWaypointList? _spawnLocations;
        [FieldAttr(160)] public CCameraBase? _camera;
        [FieldAttr(168)] public CWaypointList? _processedSpawnPoints;
    }
}
