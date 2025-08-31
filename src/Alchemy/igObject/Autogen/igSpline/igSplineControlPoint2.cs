namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class igSplineControlPoint2 : igObject
    {
        [FieldAttr(16)] public igVec3fMetaField _position = new();
        [FieldAttr(28)] public igVec3fMetaField _tangentIn = new();
        [FieldAttr(40)] public igVec3fMetaField _tangentOut = new();
        [FieldAttr(52)] public bool _smooth = true;
    }
}
