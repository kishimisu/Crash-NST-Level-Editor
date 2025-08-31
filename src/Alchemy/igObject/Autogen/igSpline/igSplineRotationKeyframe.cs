namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class igSplineRotationKeyframe : igSplineData
    {
        [FieldAttr(24)] public igVec3fMetaField _value = new();
        [FieldAttr(36)] public igVec3fMetaField _position = new();
        [FieldAttr(48)] public float _tension;
        [FieldAttr(52)] public bool _useSplinePitch;
        [FieldAttr(53)] public bool _useSplineRoll;
        [FieldAttr(54)] public bool _useSplineYaw;
    }
}
