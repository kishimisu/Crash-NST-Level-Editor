namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 8)]
    public class igSplinePoint : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public igVec3fMetaField _position = new();
        [FieldAttr(nst: 28, ctr: 24)] public igVec3fMetaField _rotation = new();
        [FieldAttr(nst: 40, ctr: 36)] public float _ratioAtPoint;
        [FieldAttr(nst: 44, ctr: 40)] public float _segmentLength;
        [FieldAttr(nst: 48, ctr: 44)] public float _distanceAtPoint;
    }
}
