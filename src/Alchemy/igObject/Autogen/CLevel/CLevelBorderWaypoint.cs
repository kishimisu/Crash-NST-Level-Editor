namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 8)]
    public class CLevelBorderWaypoint : CWaypoint
    {
        [FieldAttr(nst: 48, ctr: 40)] public float _topOffset;
        [FieldAttr(nst: 52, ctr: 44)] public float _bottomOffset;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _parent = new();
    }
}
