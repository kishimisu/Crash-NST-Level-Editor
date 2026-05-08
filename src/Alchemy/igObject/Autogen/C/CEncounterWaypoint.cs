namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 8)]
    public class CEncounterWaypoint : CWaypoint
    {
        [FieldAttr(nst: 48, ctr: 40)] public float _occupationRadiusSquared = 900.0f;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _blockingEntity = new();
    }
}
