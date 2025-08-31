namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igSplineFloatKeyframe : igSplineData
    {
        [FieldAttr(24)] public float _value;
        [FieldAttr(28)] public float _tension;
    }
}
