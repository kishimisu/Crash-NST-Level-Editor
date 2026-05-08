namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 4)]
    public class igAnimationTransitionParameters : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public float _startRatio;
        [FieldAttr(nst: 20, ctr: 16)] public float _endRatio;
        [FieldAttr(nst: 24, ctr: 20)] public int _duration;
        [FieldAttr(nst: 28, ctr: 24)] public int _targetStartTime;
    }
}
