namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class JuiceFieldTrack : JuiceFloatKeyframeList
    {
        [FieldAttr(40)] public string? _field = null;
        [FieldAttr(48)] public bool _interpolationEnabled = true;
        [FieldAttr(56)] public JuiceFloatKeyframe? _initialKeyFrame;
        [FieldAttr(64)] public bool _initialized;
        [FieldAttr(68)] public float _initialValue;
    }
}
