namespace Alchemy
{
    [ObjectAttr(40, 8, metaObject: true)]
    public class CTraversalPath : Object
    {
        [FieldAttr(32)] public CWaypointHandleList? _waypoints;
    }
}
