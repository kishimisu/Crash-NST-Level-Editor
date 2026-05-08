namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 8)]
    public class igCinematicAnimationInstance : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public float _time;
        [FieldAttr(nst: 20, ctr: 16)] public float _endTime;
        [FieldAttr(nst: 24, ctr: 20)] public float _speed = 1.0f;
        [FieldAttr(nst: 32, ctr: 24, refCount: false)] public JuiceScene? _scene;
        [FieldAttr(nst: 40, ctr: 32)] public JuiceAnimation? _animation;
        [FieldAttr(nst: 48, ctr: 40)] public bool _isStale;
    }
}
