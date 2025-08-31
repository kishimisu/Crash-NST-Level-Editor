namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class JuiceFloatKeyframe : JuiceKeyframe
    {
        [FieldAttr(24)] public float _value;
        [FieldAttr(28)] public bool _dynamic;
    }
}
