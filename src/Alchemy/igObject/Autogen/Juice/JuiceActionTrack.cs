namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class JuiceActionTrack : JuiceTrack
    {
        [FieldAttr(40)] public bool _initialized;
        [FieldAttr(44)] public float _lastTime;
    }
}
