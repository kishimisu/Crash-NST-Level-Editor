namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igSplineVec3fKeyframe : igSplineData
    {
        [FieldAttr(24)] public igVec3fMetaField _value = new();
        [FieldAttr(36)] public float _tension;
    }
}
