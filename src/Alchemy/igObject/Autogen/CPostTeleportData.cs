namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CPostTeleportData : igObject
    {
        [FieldAttr(16)] public CWaypointHandleList? _destination;
        [FieldAttr(24)] public CWaypoint? _destinationFallbackRef;
        [FieldAttr(32)] public bool _stopMomentum;
        [FieldAttr(33)] public bool _useTeam;
        [FieldAttr(40)] public igVscDelegateMetaField _onFinished = new();
        [FieldAttr(56)] public COnTeleportFinishedEventList? _onFinishedList;
    }
}
